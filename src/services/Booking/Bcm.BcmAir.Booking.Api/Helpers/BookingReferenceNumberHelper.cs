namespace Bcm.BcmAir.Booking.Api.Helpers
{
    public static class BookingReferenceNumberHelper
    {
        public static string GenerateBookingReferenceNumber()
        {
            // Dumb implementation
            return Guid.NewGuid()
                .ToString("n")
                .Substring(0, 8);
        }
    }
}
