using Application_BE_Project.Middlewares;

namespace Application_BE_Project.Extensions;

public static class ConfigureCustomMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
