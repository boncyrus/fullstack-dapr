using Bcm.BcmAir.Catalog.Api.Models.Domain;
using Dapr.Client;

namespace Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories
{
    public class FlightAvailabilityRepository : IFlightAvailabilityRepository
    {
        private readonly DaprClient _dapr;
        private readonly IFlightsRepository _flightsRepository;

        public FlightAvailabilityRepository(DaprClient dapr, IFlightsRepository flightsRepository)
        {
            _dapr = dapr;
            _flightsRepository = flightsRepository;
        }

        public async Task<bool> IsFlightAvailable(FlightNumber flightNumber)
        {
            var flights = await _flightsRepository.GetFlights();

            if (!flights.Any())
            {
                return false;
            }

            return flights
                .Any(x => x.IataCode.ToUpper() == flightNumber.IataCode.ToUpper() && x.Identifier.ToUpper() == flightNumber.Identifier.ToUpper());
        }
    }
}
