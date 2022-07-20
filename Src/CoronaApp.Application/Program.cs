using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CoronaApp.Api
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
            IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
            (configuration).CreateLogger();
            //Log.CloseAndFlush();
            CreateHostBuilder(args).Build().Run();
            //Log.CloseAndFlush();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             //.ConfigureLogging(logging =>
             //{
             //    logging.ClearProviders();
             //    logging.AddConsole();
             //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                     .UseSerilog( );
                });
    }
}
