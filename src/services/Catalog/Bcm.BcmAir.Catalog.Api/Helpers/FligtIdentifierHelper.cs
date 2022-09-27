namespace Bcm.BcmAir.Catalog.Api.Helpers
{
    public static class FligtIdentifierHelper
    {
        public static string GenerateFlightIdentifier()
        {
            var random = new Random();
            return random.Next(100, 999).ToString();
        }
    }
}
