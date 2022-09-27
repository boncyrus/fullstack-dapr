using Bcm.BcmAir.Catalog.Api.Models.Domain;

namespace Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories
{
    public interface IFlightsRepository
    {
        Task<IEnumerable<Flight>> GetFlights();
        Task<Flight> GetFlight(FlightNumber flightNumber);
        Task SellFlight(FlightNumber flightNumber, int passengerCount);
        Task SaveFlights(IEnumerable<Flight> flights);
    }
}
