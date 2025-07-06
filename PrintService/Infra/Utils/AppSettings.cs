using Microsoft.Extensions.Configuration;

namespace PrintService.Infra.Utils
{
    public static class AppSettings
    {
        public static string ConnectionString { get; private set; }
        public static short LoopDelay { get; private set; }
        public static bool IsProduction { get; private set; }

        public static void Configure(this IConfiguration configuration, bool isProdution)
        {
            ConnectionString = configuration.GetConnectionString("Default");
            LoopDelay = configuration.GetValue<short>("LoopTime");
            IsProduction = isProdution;
        }
    }
}
