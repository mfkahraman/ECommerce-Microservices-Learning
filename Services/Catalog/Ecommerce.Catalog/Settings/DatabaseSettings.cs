namespace Ecommerce.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
    }
}
