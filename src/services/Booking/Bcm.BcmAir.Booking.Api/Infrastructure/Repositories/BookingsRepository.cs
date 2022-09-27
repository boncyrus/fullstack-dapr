using Bcm.BcmAir.Infrastructure.Common.Constants;
using Dapr.Client;

namespace Bcm.BcmAir.Booking.Api.Infrastructure.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<BookingsRepository> _logger;

        public BookingsRepository(DaprClient dapr, ILogger<BookingsRepository> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        public async Task<Models.Domain.Booking> CreateBooking(Models.Domain.Booking booking)
        {
            var userBookings = (await GetUserBookings(booking.CreatedByUserId)).ToList();

            userBookings.Add(booking);

            await _dapr
                .SaveStateAsync(StateStoreConstants.BcmAirStateStore, StateKeysConstants.UserBookingsKey(booking.CreatedByUserId), userBookings);

            return booking;
        }

        public async Task<IEnumerable<Models.Domain.Booking>> GetUserBookings(Guid userId)
        {
            var userBookingsKey = StateKeysConstants.UserBookingsKey(userId);

            try
            {
                var userBookings = await _dapr
                    .GetStateAsync<IEnumerable<Models.Domain.Booking>>(StateStoreConstants.BcmAirStateStore, userBookingsKey);

                return userBookings ?? Enumerable.Empty<Models.Domain.Booking>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was a problem loading user bookings. UserId: {UserId}", userId);
                return Enumerable.Empty<Models.Domain.Booking>();
            }
        }
    }
}
