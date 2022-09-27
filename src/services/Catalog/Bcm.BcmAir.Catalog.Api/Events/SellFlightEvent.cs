using Bcm.BcmAir.Infrastructure.Common.Messaging;

namespace Bcm.BcmAir.Catalog.Api.Events
{
    public record SellFlightEvent(
        string FlightNumber,
        int PassengerCount)
        : EventMessage;
}
