using Bcm.BcmAir.Catalog.Api.Models.Domain;

namespace Bcm.BcmAir.Catalog.Api.Models
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public TravelPath Path { get; set; } = new TravelPath();
        public TravelSchedule Schedule { get; set; } = new TravelSchedule();
        public FlightNumber FlightNumber { get; set; } = new FlightNumber();
        public decimal Cost { get; set; } = 0.0m;
        public int AvailableSeats { get; set; }
    }
}
