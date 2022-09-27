using Bcm.BcmAir.Catalog.Api.Models.Domain;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Queries.FlightAvailability
{
    public class FlightAvailabilityQuery : IRequest<bool>
    {
        public FlightNumber FlightNumber { get; set; }
    }
}
