namespace Dynamic.Api.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Serilog;

    public static class LoggingConfiguration
    {
        public static void Init()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();
        }
    }
}
