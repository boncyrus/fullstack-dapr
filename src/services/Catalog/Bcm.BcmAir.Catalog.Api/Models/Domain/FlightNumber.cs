namespace Bcm.BcmAir.Catalog.Api.Models.Domain
{
    public class FlightNumber
    {
        public string IataCode { get; set; }
        public string Identifier { get; set; }

        public override string ToString()
        {
            return $"{IataCode}{Identifier}".ToUpper();
        }

        public static FlightNumber Parse(string flightNumber)
        {
            if (flightNumber.Length < 5)
            {
                throw new ArgumentException($"Invalid length for {nameof(flightNumber)}");
            }

            var iataCode = flightNumber[0..2];
            var identifier = flightNumber[2..];

            return new FlightNumber
            {
                IataCode = iataCode,
                Identifier = identifier
            };
        }
    }
}
