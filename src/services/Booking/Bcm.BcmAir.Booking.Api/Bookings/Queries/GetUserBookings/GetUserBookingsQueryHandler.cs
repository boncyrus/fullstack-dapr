using AutoMapper;
using Bcm.BcmAir.Booking.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Booking.Api.Models;
using MediatR;

namespace Bcm.BcmAir.Booking.Api.Bookings.Queries.GetUserBookings
{
    public class GetUserBookingsQueryHandler : IRequestHandler<GetUserBookingsQuery, GetUserBookingsQueryResponse>
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IMapper _mapper;

        public GetUserBookingsQueryHandler(IBookingsRepository bookingsRepository, IMapper mapper)
        {
            _bookingsRepository = bookingsRepository;
            _mapper = mapper;
        }

        public async Task<GetUserBookingsQueryResponse> Handle(GetUserBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _bookingsRepository.GetUserBookings(request.UserId);
            var userBookings = _mapper.Map<IList<BookingDto>>(bookings);

            return new GetUserBookingsQueryResponse
            {
                Bookings = userBookings
            };
        }
    }
}
