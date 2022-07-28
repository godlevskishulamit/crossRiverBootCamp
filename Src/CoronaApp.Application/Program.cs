using CoronaApp.Api.Midllewares;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
//builder.Services.AddDbContext<CoronaAppDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("home")));
builder.Services.AddControllers();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ILocationDal, LocationDal>();
builder.Services.AddScoped<IPatientDal, PatientDal>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
            (configuration).CreateLogger();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDemo v1");
        c.RoutePrefix = "swagger";
    });
    app.UseSwagger();
}
app.UseHandlerErrorsMiddleware();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
public partial class Program { }