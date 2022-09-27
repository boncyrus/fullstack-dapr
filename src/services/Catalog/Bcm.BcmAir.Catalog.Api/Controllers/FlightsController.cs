using AutoMapper;
using Bcm.BcmAir.Catalog.Api.Events;
using Bcm.BcmAir.Catalog.Api.Flights.Commands.SellFlight;
using Bcm.BcmAir.Catalog.Api.Flights.Queries.FlightAvailability;
using Bcm.BcmAir.Catalog.Api.Flights.Queries.GetFlight;
using Bcm.BcmAir.Catalog.Api.Flights.Queries.GetFlights;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using Bcm.BcmAir.Infrastructure.Common.Constants;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bcm.BcmAir.Catalog.Api.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Flights.Base)]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FlightsController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetAvailableFlights([FromBody] GetFlightsQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet(ApiRoutes.Flights.GetFlight)]
        public async Task<IActionResult> GetFlight(string flightNumber)
        {
            return Ok(await _mediator.Send(new GetFlightQuery
            {
                FlightNumber = FlightNumber.Parse(flightNumber)
            }));
        }

        [HttpGet(ApiRoutes.Flights.FlightAvailability)]
        public async Task<IActionResult> IsFlightNumberAvailable([FromRoute] string flightNumber)
        {
            return Ok(await _mediator.Send(new FlightAvailabilityQuery()
            {
                FlightNumber = FlightNumber.Parse(flightNumber)
            }));
        }

        [HttpPost(ApiRoutes.Flights.FlightSell)]
        [Topic(PubSubConstants.BcmAirPubSub, "BookingCreatedEvent")]
        public async Task<IActionResult> SellFlight(SellFlightEvent @event)
        {
            return Ok(await _mediator.Send(_mapper.Map<SellFlightCommand>(@event)));
        }
    }
}