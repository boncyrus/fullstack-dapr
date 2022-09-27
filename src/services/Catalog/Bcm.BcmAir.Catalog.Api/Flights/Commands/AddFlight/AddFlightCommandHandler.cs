using AutoMapper;
using Bcm.BcmAir.Catalog.Api.Configuration;
using Bcm.BcmAir.Catalog.Api.Helpers;
using Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Catalog.Api.Models;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using MediatR;
using Microsoft.Extensions.Options;

namespace Bcm.BcmAir.Catalog.Api.Flights.Commands.AddFlight
{
    public class AddFlightCommandHandler : IRequestHandler<AddFlightCommand, FlightDto>
    {
        private readonly IOptions<SettingsRoot> _settings;
        private readonly IMapper _mapper;
        private readonly IFlightsRepository _flightsRepository;

        public AddFlightCommandHandler(
            IOptions<SettingsRoot> settings,
            IMapper mapper,
            IFlightsRepository flightsRepository)
        {
            _settings = settings;
            _mapper = mapper;
            _flightsRepository = flightsRepository;
        }

        public async Task<FlightDto> Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flightIdentifier = string.Empty;
                var flights = await _flightsRepository
                    .GetFlights();

                var results = flights.ToList();

                var flightNumber = new FlightNumber
                {
                    Identifier = FligtIdentifierHelper.GenerateFlightIdentifier(),
                    IataCode = _settings.Value.IataCode
                };

                var flight = new Flight
                {
                    Id = Guid.NewGuid(),
                    Cost = request.Cost,
                    Destination = request.Path.Destination,
                    Origin = request.Path.Origin,
                    Departure = request.Schedule.Start,
                    Arrival = request.Schedule.End,
                    Identifier = flightNumber.Identifier,
                    IataCode = flightNumber.IataCode,
                    AvailableSeats = 100 // For demo purposes only
                };

                results.Add(flight);

                await _flightsRepository.SaveFlights(results);

                return _mapper.Map<FlightDto>(flight);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
