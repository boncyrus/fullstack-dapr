using Microsoft.AspNetCore.Mvc;

namespace Bcm.BcmAir.Catalog.Api
{
    public static class ApiRoutes 
    {
        public const string Root = "api";

        public static class Flights
        {
            public const string Base = $"{Root}/flights";
            public const string GetFlight = "{flightNumber}";
            public const string FlightAvailability = $"{{flightNumber}}/availability";
            public const string FlightSell = $"sell";
        }

        public static class FlightsManagement
        {
            public const string Base = $"{Root}/flights/management";
        }
    }
}
