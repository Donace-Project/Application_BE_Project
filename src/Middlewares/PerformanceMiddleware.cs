using Microsoft.AspNetCore.Mvc.Controllers;
using System.Diagnostics;

namespace BE_Event_Project.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PerformanceMiddleware : IMiddleware
    {
        private readonly Stopwatch stopwatch;
        public PerformanceMiddleware(Stopwatch _stopwatch)
        {
            stopwatch = _stopwatch;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var controllerActionDescriptor = context?
                                            .GetEndpoint()?
                                            .Metadata
                                            .GetMetadata<ControllerActionDescriptor>();
            var actionName = controllerActionDescriptor?.ActionName;
            stopwatch.Restart();
            stopwatch.Start();
            Console.WriteLine($"Start {controllerActionDescriptor?.ControllerTypeInfo.Name}/{actionName} performance recored");
            await next(context ?? throw new ArgumentNullException(nameof(context)));
            Console.WriteLine("End performance recored");
            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;
            Console.WriteLine("Time taken: " + timeTaken.ToString(@"m\:ss\.fff"));
        }
    }
}
