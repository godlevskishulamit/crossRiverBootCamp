using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Classes;
using CoronaApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

            services.AddScoped<ILocationDAL, LocationDAL>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IPatientDAL, PatientDAL>();
            services.AddScoped<IPatientService, PatientService>();

            services.AddDbContext<CoronaContext>(options => options.UseSqlServer(
            Configuration.GetSection("ConnectionString")["CoronaConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //app.UseExceptionHandler(c => c.Run(async context =>
            //{
            //    var exception = context.Features
            //        .Get<IExceptionHandlerPathFeature>()
            //        .Error;
            //    var response = new { error = exception.Message };
            //    await context.Response.WriteAsJsonAsync(response);
            //}));
            app.UseErrorMiddleware();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
