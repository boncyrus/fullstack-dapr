using Bcm.BcmAir.Catalog.Api.Configuration;
using Bcm.BcmAir.Catalog.Api.Helpers;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using Bcm.BcmAir.Infrastructure.Common.Constants;
using Dapr.Client;
using Microsoft.Extensions.Options;

namespace Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly DaprClient _daprClient;
        private readonly ILogger<FlightsRepository> _logger;
        private readonly IOptions<SettingsRoot> _settings;

        public FlightsRepository(DaprClient daprClient, ILogger<FlightsRepository> logger, IOptions<SettingsRoot> settings)
        {
            _daprClient = daprClient;
            _logger = logger;
            _settings = settings;
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            try
            {
                var flights = await _daprClient.GetStateAsync<IEnumerable<Flight>>(StateStoreConstants.BcmAirStateStore, StateKeysConstants.Flights);
                var result = flights?.ToList() ?? new List<Flight>();

                // Seed for demo purposes only.
                if (!result.Any())
                {
                    var random = new Random();
                    for (var i = 0; i < 3; i++)
                    {
                        var departure = DateTime.UtcNow.AddDays(random.Next(2, 5));
                        var flight = new Flight
                        {
                            Id = Guid.NewGuid(),
                            Cost = random.Next(),
                            Destination = "CEB",
                            Origin = "MNL",
                            Departure = departure,
                            Arrival = departure.AddDays(1),
                            Identifier = FligtIdentifierHelper.GenerateFlightIdentifier(),
                            IataCode = _settings.Value.IataCode,
                            AvailableSeats = 100 // For demo purposes only
                        };

                        result.Add(flight);
                    }

                    await SaveFlights(result);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed fetching flights.");
                return new List<Flight>();
            }
        }

        public async Task SellFlight(FlightNumber flightNumber, int passengerCount)
        {
            var flights = await GetFlights();

            var flight = await GetFlight(flightNumber);

            if (flight == null)
            {
                return;
            }

            var remainingSeats = flight.AvailableSeats - passengerCount;

            if (remainingSeats < 0)
            {
                remainingSeats = 0;
            }

            flight.AvailableSeats = remainingSeats;

            await SaveFlights(flights);
        }

        public Task SaveFlights(IEnumerable<Flight> flights)
        {
            return _daprClient.SaveStateAsync(StateStoreConstants.BcmAirStateStore, StateKeysConstants.Flights, flights ?? Enumerable.Empty<Flight>());
        }

        public async Task<Flight> GetFlight(FlightNumber flightNumber)
        {
            var flights = await GetFlights();
            return flights
                .FirstOrDefault(x => x.IataCode.ToLower() == flightNumber.IataCode.ToLower()
                    && x.Identifier.ToLower() == flightNumber.Identifier.ToLower());
        }
    }
}
