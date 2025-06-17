using Flafel.Applications.UnitOfWork;
using Flafel.Infrastructure.Data;
using Flafel.Infrastructure.Data.Interceptors;
using Flafel.Infrastructure.Helpers;
using Flafel.Infrastructure.Repositories;
using Flafel.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flafel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(configuration.GetConnectionString("Database"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();

            services.AddScoped<IUserRepository, UserRepository<ApplicationDbContext>>();

            services.AddTransient<InitialDatabase>();

            return services;
        }
    }
}
