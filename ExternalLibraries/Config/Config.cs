using Microsoft.Extensions.Configuration;

namespace ExternalLibraries.ConfigSystem
{
    public class Config : IConfig
    {
        private static IConfiguration _config;

        public Config()
        {
            if (_config == null)
                _config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public string Get(string key)
        {
            return _config[key];
        }
    }
}
