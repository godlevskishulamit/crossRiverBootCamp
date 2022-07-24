//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using CoronaApp.Dal;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore;
//using CoronaApp.Dal.models;
//using System.Text.Json.Serialization;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Http;
//using CoronaApp.Api.Middlewares;
//using CoronaApp.Services;

//namespace CoronaApp.Api
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddDbContext<CoronaAppContext>
//               (item => item.UseSqlServer(Configuration.GetConnectionString("connectionDBMiriam")));
//            services.AddControllers();
//            services.AddScoped<IPatientDal, PatientDal>();
//            services.AddScoped<IPatientRepository, PatientRepository>();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//              //  app.UseSwagger();
//               // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoronaApp v1"));
//            }

//            app.UseHttpsRedirection();
//       //     app.UseHandleErrorMiddleware();


//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
