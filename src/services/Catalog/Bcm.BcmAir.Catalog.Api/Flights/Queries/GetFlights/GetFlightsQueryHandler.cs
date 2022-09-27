using AutoMapper;
using Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Catalog.Api.Models;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Queries.GetFlights
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, GetFlightsQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFlightsRepository _flightsRepository;

        public GetFlightsQueryHandler(IFlightsRepository flightsRepository, IMapper mapper)
        {
            _flightsRepository = flightsRepository;
            _mapper = mapper;
        }

        public async Task<GetFlightsQueryResponse> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightsRepository.GetFlights();

            if (request.Range != null
                && request.Range.Start != DateTime.MinValue && request.Range.End != DateTime.MinValue && request.Range.Start <= request.Range.End)
            {
                flights = flights.Where(x => x.Departure >= request.Range.Start && x.Arrival <= request.Range.End);
            }

            if (!string.IsNullOrEmpty(request.FlightNumber))
            {
                var flightNumberParsed = FlightNumber.Parse(request.FlightNumber);
                flights = flights
                    .Where(x => x.IataCode.Equals(flightNumberParsed.IataCode, StringComparison.InvariantCultureIgnoreCase) 
                                && x.Identifier.Equals(flightNumberParsed.Identifier, StringComparison.InvariantCultureIgnoreCase));
            }

            return new GetFlightsQueryResponse
            {
                Flights = _mapper.Map<IEnumerable<FlightDto>>(flights)
            };
        }
    }
}
