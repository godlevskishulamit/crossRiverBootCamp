using CoronaApp.Api.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HandlerErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandlerErrorMiddleware> _ilogger;
        public HandlerErrorMiddleware(RequestDelegate next, ILogger<HandlerErrorMiddleware> ilogger)
        {
            _ilogger = ilogger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode > 400 && httpContext.Response.StatusCode < 500)
                {
                    throw new Exception("Not Found");
                }
            }
            catch (Exception ex)
            {
                _ilogger.Log(LogLevel.Information, ex.Message);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandleErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandleErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandlerErrorMiddleware>();
        }
    }
}
