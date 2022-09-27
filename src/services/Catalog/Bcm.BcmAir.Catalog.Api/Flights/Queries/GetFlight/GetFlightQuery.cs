using Bcm.BcmAir.Catalog.Api.Models;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Queries.GetFlight
{
    public class GetFlightQuery : IRequest<FlightDto>
    {
        public FlightNumber FlightNumber { get; set; }
    }
}
