using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CoronaApp.Api.Middlewares;

public class ValidationErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationErrorHandler> _logger;

    public ValidationErrorHandler(RequestDelegate next, ILogger<ValidationErrorHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
            if (httpContext.Response.StatusCode == 400)
            {
                throw new ValidationException("model is invalid xxxxxxxxx");
            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "model is invalid xxxxxxxxx");
            throw ex;
        }
    }
}

public static class ValidationErrorHandlerExtensions
{
    public static IApplicationBuilder UseValidationErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidationErrorHandler>();
    }
}
