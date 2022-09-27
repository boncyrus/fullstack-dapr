using Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Catalog.Api.Models.Domain;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Commands.SellFlight
{
    public class SellFlightCommandHandler : IRequestHandler<SellFlightCommand, Unit>
    {
        private readonly IFlightsRepository _flightsRepository;

        public SellFlightCommandHandler(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }

        public async Task<Unit> Handle(SellFlightCommand request, CancellationToken cancellationToken)
        {
            await _flightsRepository.SellFlight(FlightNumber.Parse(request.FlightNumber), request.PassengerCount);
            return Unit.Value;
        }
    }
}
