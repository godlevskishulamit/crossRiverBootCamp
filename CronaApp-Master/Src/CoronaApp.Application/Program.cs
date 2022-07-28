using CoronaApp.Api.Middlewares;
using CoronaApp.Dal;
using CoronaApp.Dal.models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;

using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("conLeah");
builder.Services.AddDbContext<CoronaAppContext>(options => options.UseSqlServer(connectionString));

var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();


builder.Host.UseSerilog();


builder.Services.AddScoped<IPatientDal, PatientDal>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ILocationDal, LocationDal>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("key").Value);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
{
    
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
    };
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UseHsts();
}
app.UseHttpsRedirection();

app.UseHandleErrorMiddleware();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
app.Run();

//;

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)