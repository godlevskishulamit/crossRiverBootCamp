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
            if(httpContext.Response.StatusCode is > 400 and < 500)
                throw new KeyNotFoundException("Not Found");
        }
        catch (Exception error)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            _logger.Log(LogLevel.Error, error.Message);
            switch (error)
            {
                case ArgumentNullException e:
                    // custom application error
                    await response.WriteAsync($"Oppps... \n the argument {e.Message} is null!");
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // not found error
                    await response.WriteAsync("Oppps... \n Page Not Found!");
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    await response.WriteAsync("Oppps... \n we are trying to fix the problem!");
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
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