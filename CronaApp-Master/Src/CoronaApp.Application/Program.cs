using CoronaApp.Api;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
// Add services to the container.
string AllowAll = "AllowAll";//
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAll
                      , policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();

                      });
});
IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();////
Log.Logger = new LoggerConfiguration().
    ReadFrom.Configuration(configuration).
    Enrich.FromLogContext().
    CreateLogger();
builder.Services.AddDbContext<CoronaDBContext>
                (item => item.UseSqlServer(configuration.GetConnectionString("connectionToCoronaDB")));//
var securityKey = Encoding.ASCII.GetBytes(configuration["JWT:key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(securityKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoronaApp.Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();////

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();////
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEventHandlerMiddleware();
app.UseRouting();//
app.UseAuthentication();//
app.UseAuthorization();
app.UseCors(AllowAll);//
app.UseEndpoints(endpoints =>//
{
    endpoints.MapControllers();//
});
app.UseHttpsRedirection();

//app.MapControllers();
app.Run();
public partial class Program { }