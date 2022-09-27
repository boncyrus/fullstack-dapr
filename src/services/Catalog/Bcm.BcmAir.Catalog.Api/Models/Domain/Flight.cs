namespace Bcm.BcmAir.Catalog.Api.Models.Domain
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Identifier { get; set; }
        public string IataCode { get; set; }
        public decimal Cost { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int AvailableSeats { get; set; }
    }
}
