using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    public class ErrorMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            
            _logger.LogError(new Exception("check"), "request path: " + httpContext.Request.Path);

            //try
            //{
                await _next(httpContext);
                if (httpContext.Response.StatusCode == 404)
                    await httpContext.Response.WriteAsJsonAsync("returned with 404 code");
                
            //
            //catch(Exception ex)
            //{

            //   httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //}
        }
    }

    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
