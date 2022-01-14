namespace iTechArtPizzaDelivery.Core.Configurations
{
    public class IdentityConfiguration
    {
        public string UserRole { get; set; }

        public string SecurityKey { get; set; }
        public int ExpiresHours { get; set; }
    }
}