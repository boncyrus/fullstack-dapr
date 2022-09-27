namespace Bcm.BcmAir.Booking.Api.Infrastructure
{
    public class StateKeysConstants
    {
        public static string UserBookingsKey(Guid userId) => $"{userId}-user-bookings";
    }
}
