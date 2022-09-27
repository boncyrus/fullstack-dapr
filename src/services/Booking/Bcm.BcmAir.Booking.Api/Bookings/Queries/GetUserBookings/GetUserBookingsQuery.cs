using Bcm.BcmAir.Booking.Api.Models;
using MediatR;

namespace Bcm.BcmAir.Booking.Api.Bookings.Queries.GetUserBookings
{
    public class GetUserBookingsQueryResponse
    {
        public IEnumerable<BookingDto> Bookings { get; set; } = Enumerable.Empty<BookingDto>();
    }

    public class GetUserBookingsQuery : IRequest<GetUserBookingsQueryResponse>
    {
        public Guid UserId { get; set; }
    }
}
