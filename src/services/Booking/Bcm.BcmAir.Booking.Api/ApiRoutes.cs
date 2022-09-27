namespace Bcm.BcmAir.Booking.Api
{
    public static class ApiRoutes
    {
        public static class Bookings
        {
            public const string Base = "api/bookings";
            public const string CreateBooking = $"{Base}";
            public const string GetUserBookings = $"users/{{userId}}";
        }
    }
}
