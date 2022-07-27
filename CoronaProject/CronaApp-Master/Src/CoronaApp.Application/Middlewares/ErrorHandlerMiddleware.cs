using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CoronaApp.Api.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        
        try
        {
            await _next(httpContext);
            //throw on exception when model is invalid

            if (httpContext.Response.StatusCode == 400)
            {
                //httpContext.Response
                //    response.StatusCode = (int)HttpStatusCode.BadRequest;

                // throw new Exception("model is invalid");
                _logger.LogInformation("model is invalid");
             _logger.LogError("model is invalid - ERROR!!!");
            }

               
        }
        catch (Exception ex)
        {
            throw ex;
        }
       

    }
}
// Extension method used to add the middleware to the HTTP request pipeline.
public static class ErrorHandlerMiddlewareExtensions
{
    public static void UseErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
         builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}