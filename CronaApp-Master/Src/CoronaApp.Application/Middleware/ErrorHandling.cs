using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CoronaApp.Api.Middleware
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;
         ILogger<ErrorHandling> _logger;
        public ErrorHandling(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, ILogger<ErrorHandling> logger)
        {
            _logger = logger;
            try
            {
                await _next(httpContext);
                int status = httpContext.Response.StatusCode;
                if (status == 400 || status == 405)
                {
                    _logger.LogError("Not enough information");
                }
                if (status == 404)
                {
                    _logger.LogError("404 error");
                }
                if (status == 500)
                {
                    _logger.LogError("Status code: 500");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error from my middleware" + e.Message + "Stack error is:" + e.StackTrace);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandelingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandling>();
        }
    }
}
