//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Serilog;

//namespace CoronaApp.Api
//{
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//        .ConfigureLogging(logging =>
//        {
//            logging.ClearProviders();
//            logging.AddConsole();
//        })
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        });
//}
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            IConfigurationRoot configuration = new
//            ConfigurationBuilder().AddJsonFile("appsettings.json",
//            optional: false, reloadOnChange: true).Build();
//            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
//            (configuration).CreateLogger();
//            BuildWebHost(args).Run();
//        }

//        public static IWebHost BuildWebHost(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>()
//                .UseSerilog()
//                .Build();
//    }
//}
using CoronaApp.Api.Middlewares;
using CoronaApp.Dal;
using CoronaApp.Dal.models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("conLeah");
builder.Services.AddDbContext<CoronaAppContext>(options => options.UseSqlServer(connectionString));

builder.Logging.ClearProviders();
var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .MinimumLevel.Override("Serilog", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .Enrich.WithClientIp()
                .Enrich.WithClientAgent()
                .CreateLogger();

Log.Logger = logger;
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddScoped<IPatientDal, PatientDal>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ILocationDal, LocationDal>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseHandleErrorMiddleware();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
app.Run();

