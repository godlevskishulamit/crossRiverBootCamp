using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project

public class EventHandlerMiddleware
{
    private readonly RequestDelegate _next;
    ILogger<EventHandlerMiddleware> _logger;
    public EventHandlerMiddleware(RequestDelegate next, ILogger<EventHandlerMiddleware> logger)
    {
        _logger = logger;
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

            _logger.LogError($"Error: {ex.Message} Stack trace:{ex.StackTrace}");
            if (!(httpContext.Response.StatusCode is 400 and < 500))
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
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

