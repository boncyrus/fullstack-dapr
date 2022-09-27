using Bcm.BcmAir.Catalog.Api.Flights.Commands;
using Bcm.BcmAir.Catalog.Api.Flights.Commands.AddFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bcm.BcmAir.Catalog.Api.Controllers
{
    [ApiController]
    [Route(ApiRoutes.FlightsManagement.Base)]
    public class FlightsManagementController : ControllerBase
    {
        private IMediator _mediator;
        private ILogger<FlightsManagementController> _logger;

        public FlightsManagementController(IMediator mediator, ILogger<FlightsManagementController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] AddFlightCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
