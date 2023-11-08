using System.Diagnostics;

using Application_BE_Project.EntityFramework;
using Application_BE_Project.Interfaces;
using Application_BE_Project.Middlewares;

using EntityFramework.Repository;

namespace Application_BE_Project.Extensions
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
