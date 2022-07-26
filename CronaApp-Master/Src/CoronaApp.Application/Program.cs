using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Api;
using CoronaApp.Dal.Functions;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Dal.Services;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
//Add Services
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationDal, LocationDal>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddDbContext<CoronaContext>(item => item.UseSqlServer("Server = DESKTOP-0OR8G5P\\ADINA; Database = CoronaApp; Trusted_Connection = true"));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
    {
        p.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

IConfigurationRoot configuration = new
    ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

var app = builder.Build();
//Configure for Http pipleline

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseErrorHandelingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

//namespace CoronaApp.Api
//{
   
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            IConfigurationRoot configuration = new
//             ConfigurationBuilder().AddJsonFile("appsettings.json",
//             optional: false, reloadOnChange: true).Build();
//            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
//            (configuration).CreateLogger();
//            CreateHostBuilder(args).Build().Run();


//        }

//        public static IHostBuilder CreateHostBuilder(string[] args)
//        {
//            return Host.CreateDefaultBuilder(args)
//                .ConfigureLogging((context, logging) =>
//                {
//                    logging.ClearProviders();
//                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
//                    logging.AddDebug();
//                    logging.AddConsole();
//                })
//            .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>().UseSerilog();
//        });
//        }
//    }
//}

