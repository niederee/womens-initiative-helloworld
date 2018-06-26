using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace HelloWorld
{
    public static class ConfigService
    {
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json",
            optional: true,
            reloadOnChange: true);

            return builder.Build();
        }
    }
}