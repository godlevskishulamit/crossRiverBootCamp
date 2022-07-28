using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoronaApp.Api;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class Middleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<Middleware> _logger;
    public string Meesege { get; set; }
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
            switch (httpContext.Response.StatusCode)
            {
                case 204:
                    Meesege = "no content for the required information";
                    await HandleExceptionAsync(httpContext, new Exception(Meesege));
                    _logger.LogWarning(Meesege);
                    break;
                case 400:
                    Meesege = "bad request";
                    await HandleExceptionAsync(httpContext, new Exception(Meesege));
                    _logger.LogError(Meesege);
                    break;
                case 401:
                    Meesege = "unAuthorized";
                    await HandleExceptionAsync(httpContext, new Exception(Meesege));
                    _logger.LogError(Meesege);
                    break;
                case 404:
                    Meesege = "the required information was not found please check your values";
                    await HandleExceptionAsync(httpContext, new Exception(Meesege));
                    _logger.LogError(Meesege);
                    break;
                case 405:
                    Meesege = "check your URL";
                    await HandleExceptionAsync(httpContext, new Exception(Meesege));
                    _logger.LogError(Meesege);
                    break;
                case 500:
                    Meesege = "go complain to your the programmer it's our problem";
                    await HandleExceptionAsync(httpContext, new Exception(Meesege));
                    _logger.LogError(Meesege);
                    break;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex.Message}");
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var result = JsonConvert.SerializeObject(new { error = ex.Message });
        return context.Response.WriteAsync(result);
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
