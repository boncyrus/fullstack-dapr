namespace Bcm.BcmAir.Booking.Api.Models
{
    public class BookingDto
    {
        public Guid CreatedByUserId { get; set; }
        public string ReferenceNumber { get; set; }
        public string FlightNumber { get; set; }
        public IList<BookingPassengerDetailDto> Passengers { get; set; } = new List<BookingPassengerDetailDto>();
    }
}
