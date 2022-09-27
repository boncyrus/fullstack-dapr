using Bcm.BcmAir.Infrastructure.Common.Messaging;

namespace Bcm.BcmAir.Booking.Api.Events
{
    public record BookingCreatedEvent(
        string FlightNumber,
        int PassengerCount)
        : EventMessage;
}
