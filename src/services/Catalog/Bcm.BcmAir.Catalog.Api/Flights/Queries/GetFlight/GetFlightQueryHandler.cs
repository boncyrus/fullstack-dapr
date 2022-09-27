using AutoMapper;
using Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Catalog.Api.Models;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Queries.GetFlight
{
    public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, FlightDto>
    {
        private readonly IFlightsRepository _flightsRepository;
        private readonly IMapper _mapper;

        public GetFlightQueryHandler(IFlightsRepository flightsRepository, IMapper mapper)
        {
            _flightsRepository = flightsRepository;
            _mapper = mapper;
        }

        public async Task<FlightDto> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await _flightsRepository.GetFlight(request.FlightNumber);

            if (flight == null)
            {
                return null;
            }

            return _mapper.Map<FlightDto>(flight);
        }
    }
}
