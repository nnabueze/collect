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

            try
            {
                Console.WriteLine("Ercas Collect service started");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
