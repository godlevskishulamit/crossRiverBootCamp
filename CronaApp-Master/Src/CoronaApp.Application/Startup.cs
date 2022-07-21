using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoronaApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IMockDalPatient, MockDataPatient>();
            services.AddScoped<IDalPatient, DalPatient>();
            services.AddScoped<IDalLocation, DalLocation>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddMvc();
            services.AddDbContext<CoronaDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> _logger)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseExceptionHandler(a => a.Run(async context =>
            //{
            //    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            //    var exception = exceptionHandlerPathFeature.Error;
            //    _logger.LogError($"Something went wrong: {exception.Message}");

            //    //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            //}));
            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
