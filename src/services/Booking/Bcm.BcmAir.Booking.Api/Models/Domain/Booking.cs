namespace Bcm.BcmAir.Booking.Api.Models.Domain
{
    public class Booking
    {
        public Guid CreatedByUserId { get; set; }
        public string ReferenceNumber { get; set; }
        public string FlightNumber { get; set; }
        public IList<BookingPassengerDetail> Passengers { get; set; } = new List<BookingPassengerDetail>();
    }
}
