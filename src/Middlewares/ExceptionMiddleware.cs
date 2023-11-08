using Application_BE_Project.Exceptions;
using Application_BE_Project.Shared;
using System.Net;

namespace Application_BE_Project.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (FriendlyException fex)
        {
            _logger.LogError($"A new violation exception has been thrown: {fex}");
            await HandleExceptionAsync(httpContext, fex);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        switch (exception)
        {
            case FriendlyException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = (exception as FriendlyException).Code,
                    Message = exception.Message,
                    Data = exception.Data,
                }.ToString());
                break;

            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode.ToString(),
                    Message = "Internal Server Error from the custom middleware."
                }.ToString());
                break;
        }
    }
}
