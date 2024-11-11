using Serilog;

namespace tm_api
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
            var host = CreateHostBuilder(args).Build();
            Log.Information("MMSC App BE is running");
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
                    var env = hostingContext.HostingEnvironment;
                    config.Sources.Clear();
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureLogging((hostingContext, logging) =>
                        {
                            var enableLog = hostingContext.Configuration.GetValue<bool>("EnableLog");
                            if (!enableLog)
                            {
                                logging.ClearProviders();
                            }
                        });
                });
    }
}
