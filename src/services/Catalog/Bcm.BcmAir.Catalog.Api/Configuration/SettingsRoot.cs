namespace Bcm.BcmAir.Catalog.Api.Configuration
{
    public class SettingsRoot
    {
        public ConnectionStrings ConnectionStrings { get; protected set; } = new ConnectionStrings();
        public string IataCode { get; set; }
    }
}
