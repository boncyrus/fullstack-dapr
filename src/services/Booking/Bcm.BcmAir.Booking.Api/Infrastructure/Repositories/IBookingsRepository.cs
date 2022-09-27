using System.Collections.Generic;
using System;

namespace Bcm.BcmAir.Booking.Api.Infrastructure.Repositories
{
    public interface IBookingsRepository
    {
        Task<Models.Domain.Booking> CreateBooking(Models.Domain.Booking booking);
        Task<IEnumerable<Models.Domain.Booking>> GetUserBookings(Guid userId);
    }
}
