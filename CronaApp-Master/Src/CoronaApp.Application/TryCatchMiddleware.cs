using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TryCatchMiddleware
    {
        private readonly RequestDelegate _next;

        public TryCatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {

                await _next(httpContext);
            }
            catch (Exception ex)
            {
           throw ex;
               
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TryCatchMiddlewareExtensions
    {
        public static IApplicationBuilder UseTryCatchMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TryCatchMiddleware>();
        }
    }
}
