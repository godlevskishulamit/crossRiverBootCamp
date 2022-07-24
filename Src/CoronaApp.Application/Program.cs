using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Classes;
using CoronaApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;
using NLog;
using Log = Serilog.Log;

var Builder = WebApplication.CreateBuilder(args);

Builder.Host.UseSerilog();

Builder.Services.AddControllers();

Builder.Services.AddEndpointsApiExplorer();
Builder.Services.AddSwaggerGen();

Builder.Services.AddScoped<ILocationDAL, LocationDAL>();
Builder.Services.AddScoped<ILocationService, LocationService>();
Builder.Services.AddScoped<IPatientDAL, PatientDAL>();
Builder.Services.AddScoped<IPatientService, PatientService>();

Builder.Host.UseSerilog();
IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json",
     optional: false, reloadOnChange: true).Build();
//Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

Builder.Services.AddDbContext<CoronaContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionString")["CoronaConnection"]));


var app = Builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();




