using BE_Event_Project.Middlewares;

namespace BE_Event_Project.Extensions;

public static class ConfigureCustomMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
