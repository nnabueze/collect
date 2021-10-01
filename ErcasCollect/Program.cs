using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ErcasCollect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //setting serilog
            var configuration = new ConfigurationBuilder()

                .AddJsonFile("appsettings.json")

                .Build();

            Log.Logger = new LoggerConfiguration()

                .ReadFrom.Configuration(configuration)

                .CreateLogger();

            try
            {
                Console.WriteLine("Ercas Collect service started");

                Log.Information("Ercas Collect service started");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ercas Collect failed");

                Console.WriteLine("Ercas Collect service failed....");

                Console.WriteLine(ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
