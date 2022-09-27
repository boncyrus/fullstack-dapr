using Bcm.BcmAir.Catalog.Api.Models;
using Bcm.BcmAir.Common.Models;
using MediatR;

namespace Bcm.BcmAir.Catalog.Api.Flights.Queries.GetFlights
{
    public class GetFlightsQueryResponse
    {
        public IEnumerable<FlightDto> Flights { get; set; } = new List<FlightDto>();
    }

    public class GetFlightsQuery : IRequest<GetFlightsQueryResponse>
    {
        public DateRange Range { get; set; } = new DateRange();
        public string FlightNumber { get; set; } = string.Empty;
    }
}
