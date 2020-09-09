using Data.Configuration;

namespace Data.Configuration
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set; }
    }
}