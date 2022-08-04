using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EventHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public EventHandlerMiddleware(RequestDelegate next)
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
    public static class EventHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseEventHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EventHandlerMiddleware>();
        }
    }
}
