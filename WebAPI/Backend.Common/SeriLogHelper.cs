using Microsoft.Extensions.Configuration;
using Serilog;

namespace Backend.Common
{
    public static class SeriLogHelper
    {
        public static void UseCustomizedSerilog(string environmentName, IConfiguration configuration)
        {
            var logConfiguration = new LoggerConfiguration().ReadFrom.Configuration(configuration).Enrich.FromLogContext();
            Log.Logger = logConfiguration.CreateLogger();  
        }
    }
}