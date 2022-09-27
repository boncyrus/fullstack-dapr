using Bcm.BcmAir.Booking.Api.Models.Domain;

namespace Bcm.BcmAir.Booking.Api.Models
{
    public class BookingPassengerDetailDto
    {
        public Name Name { get; set; }
        public Gender Gender { get; set; }
        public string SeatNumber { get; set; }
    }
}
