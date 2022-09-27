using Bcm.BcmAir.Catalog.Api.Models;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Commands
{
    public class AddFlightCommand : IRequest<FlightDto>
    {
        public TravelPath Path { get; set; }
        public TravelSchedule Schedule { get; set; } = new TravelSchedule();
        public decimal Cost { get; set; } = 0.0m;
    }
}
