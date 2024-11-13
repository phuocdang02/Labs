using Serilog;

namespace ECenterFlow
{
    /// <summary>
    /// Represents an Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            Log.Information("ECenter Flow API is running...");
            host.Run();
        }

        /// <summary>
        /// Represents an HostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                IHostEnvironment env = hostingContext.HostingEnvironment;
                config.Sources.Clear();
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>().ConfigureLogging((hostingContext, logging) =>
                {
                    bool enableLog = hostingContext.Configuration.GetValue<bool>("EnableLog");
                    if (!enableLog)
                        logging.ClearProviders();
                });
            });
    }
}