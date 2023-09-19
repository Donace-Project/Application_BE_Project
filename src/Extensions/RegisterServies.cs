using System.Diagnostics;

using BE_Event_Project.EntityFramework;
using BE_Event_Project.Interfaces;
using BE_Event_Project.Middlewares;

using EntityFramework.Repository;

namespace BE_Event_Project.Extensions
{
    public static class RegisterServies
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {

            //services.AddSingleton(FirebaseApp.Create());

            services.AddDbContext<AppDbContext>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            return services;
        }
    }
}
