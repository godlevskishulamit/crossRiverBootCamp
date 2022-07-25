
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using CoronaApp.Api;
using Serilog;
using CoronaApp.Dal.Models;
using Microsoft.Extensions.DependencyInjection;
using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

//Add Services to the containe
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

var connectipnString = builder.Configuration.GetConnectionString("home");
builder.Services.AddDbContext<CoronaAppDBContext>(options => options.UseSqlServer(connectipnString));
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ILocationDal, LocationDal>();
builder.Services.AddScoped<IPatientDal, PatientDal>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoronaApp.Api", Version = "v1" });
});
IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
            (configuration).CreateLogger();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoronaApp.Api v1");
        //c.RoutePrefix = string.Empty;

    });
}
app.UseEventHandlerMiddleWare();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
public partial class Program { }
