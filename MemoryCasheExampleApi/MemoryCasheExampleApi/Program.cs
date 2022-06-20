using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MemoryCasheExampleApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).ConfigureAppConfiguration(
                (hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", true, false);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
                        false);
                    config.AddEnvironmentVariables();
                });
    }
}