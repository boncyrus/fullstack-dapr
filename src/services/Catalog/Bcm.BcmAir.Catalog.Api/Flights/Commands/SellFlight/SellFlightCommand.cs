using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Commands.SellFlight
{
    public class SellFlightCommand : IRequest<Unit>
    {
        public string FlightNumber { get; set; }
        public int PassengerCount { get; set; }
    }
}
