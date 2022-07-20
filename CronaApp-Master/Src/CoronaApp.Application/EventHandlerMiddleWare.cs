using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EventHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public string Message { get; set; }
        public EventHandlerMiddleWare(RequestDelegate next, ILogger<EventHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

       /* public void OnGet()
        {
            Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);
        }*/
        public async Task Invoke(HttpContext httpContext, ILogger<EventHandlerMiddleWare> logger)
        {
            try
            {
                Message = $"Message From My Logger {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);
                await _next(httpContext);
                if (httpContext.Response.StatusCode >= 400 && httpContext.Response.StatusCode < 500)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                logger.LogError("Error from My MiddleWAre : " + ex.Message + "stack Trace is:" + ex.StackTrace);
                if (httpContext.Response.StatusCode >= 400 && httpContext.Response.StatusCode < 500)
                    httpContext.Response.StatusCode = httpContext.Response.StatusCode;
                else
                httpContext.Response.StatusCode = 500;
                //httpContext.Response.ContentType = ex;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseEventHandlerMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EventHandlerMiddleWare>();
        }
    }
}
