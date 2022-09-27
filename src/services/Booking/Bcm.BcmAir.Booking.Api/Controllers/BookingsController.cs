using Bcm.BcmAir.Booking.Api.Bookings.Commands.CreateBooking;
using Bcm.BcmAir.Booking.Api.Bookings.Queries.GetUserBookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bcm.BcmAir.Booking.Api.Controllers
{
    [Route(ApiRoutes.Bookings.Base)]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand request)
        {
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Bookings.GetUserBookings)]
        public async Task<IActionResult> GetUserBookings(Guid userId)
        {
            return Ok(await _mediator.Send(new GetUserBookingsQuery
            {
                UserId = userId
            }));
        }
    }
}
