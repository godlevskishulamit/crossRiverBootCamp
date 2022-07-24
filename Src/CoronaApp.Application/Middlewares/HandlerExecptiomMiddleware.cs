using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CoronaApp.Api.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class HandlerExecptiomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HandlerExecptiomMiddleware> _logger;

    public HandlerExecptiomMiddleware(RequestDelegate next, ILogger<HandlerExecptiomMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            _logger.LogInformation("i'm in middleware");
            await _next(httpContext);
            if (httpContext.Response.StatusCode > 400 && httpContext.Response.StatusCode < 500)
            {
                throw new Exception("error between 400-500");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("it's error! " + ex.Message);
            throw new Exception(ex.Message);
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class HandlerExecptiomMiddlewareExtensions
{
    public static IApplicationBuilder UseHandlerExecptiomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandlerExecptiomMiddleware>();
    }
}