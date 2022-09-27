using Bcm.BcmAir.Catalog.Api.Models.Domain;

namespace Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories
{
    public interface IFlightAvailabilityRepository
    {
        Task<bool> IsFlightAvailable(FlightNumber flightNumber);
    }
}
