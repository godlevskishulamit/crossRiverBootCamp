using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
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
            CreateHostBuilder(args).Build().Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddConsole();
                })
            .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>().UseSerilog();
        });
        }
    }
}

