using Bcm.BcmAir.Booking.Api.Models;
using MediatR;

namespace Bcm.BcmAir.Booking.Api.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<BookingDto>
    {
        public Guid UserId { get; set; }
        public string FlightNumber { get; set; }
        public IList<BookingPassengerDetailDto> Passengers { get; set; } = new List<BookingPassengerDetailDto>();
    }
}
