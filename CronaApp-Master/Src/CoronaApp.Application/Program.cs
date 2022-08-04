using CoronaApp.Api;
using CoronaApp.Dal;
using CoronaApp.Dal.Dal;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Interfaces;
using CoronaApp.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FBI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }
                });
});
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//});
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
//                 {
//                     cfg.RequireHttpsMetadata = false;
//                     cfg.TokenValidationParameters = FbiTokenService.GetTokenValidationParameters();
//                 });
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});
builder.Services.AddScoped<IDalLocation, DalLocation>();
builder.Services.AddScoped<IDalPatient, DalPatient>();
builder.Services.AddScoped<IDalUser, DalUser>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMvc();
//builder.Services.AddDbContext<CoronaDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));
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
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseAuthentication();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});
app.UseHttpsRedirection();

app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
