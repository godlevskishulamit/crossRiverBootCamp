using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CoronaApp.Api;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class Middleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<Middleware> _logger;
    public Middleware(RequestDelegate next, ILogger<Middleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {

        try 
        { 
            await _next(httpContext);
            if (httpContext.Response.StatusCode == 204)
                _logger.LogWarning("no content for the required information");
            if (httpContext.Response.StatusCode==404)
                _logger.LogError("the required information was not found please check your values");
            if (httpContext.Response.StatusCode == 405)
                _logger.LogError("check your URL");
            if (httpContext.Response.StatusCode == 500)
                _logger.LogError("go complain to your the programmer it's our problem");

            

        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex.Message}");
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<Middleware>();
    }
}
