using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoronaApp.Api;

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
        try
        {
            //_logger.LogInformation("in log info");
            await _next(httpContext);
            if (httpContext.Response.StatusCode >= 400 && httpContext.Response.StatusCode < 500)
                await httpContext.Response.WriteAsJsonAsync("returned with 404 code");
        }
        catch (Exception ex)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            _logger.LogError(ex.Message);
            switch (ex)
            {
                case ArgumentNullException e:
                    await response.WriteAsync($"Oppps... \n the argument {e.Message} is null!");
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    await response.WriteAsync("Oppps... \n Page Not Found!");
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    await response.WriteAsync("Oppps... \n we are trying to fix the problem!");
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }
}

public static class ErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorMiddleware>();
    }
}
