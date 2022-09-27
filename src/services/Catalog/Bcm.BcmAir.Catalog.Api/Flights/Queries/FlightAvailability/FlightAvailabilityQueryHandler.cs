using Bcm.BcmAir.Catalog.Api.Infrastructure.Repositories;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Queries.FlightAvailability
{
    public class FlightAvailabilityQueryHandler : IRequestHandler<FlightAvailabilityQuery, bool>
    {
        private readonly IFlightAvailabilityRepository _flightAvailabilityRepository;

        public FlightAvailabilityQueryHandler(IFlightAvailabilityRepository flightAvailabilityRepository)
        {
            _flightAvailabilityRepository = flightAvailabilityRepository;
        }

        public Task<bool> Handle(FlightAvailabilityQuery request, CancellationToken cancellationToken)
        {
            return _flightAvailabilityRepository.IsFlightAvailable(request.FlightNumber);
        }
    }
}
