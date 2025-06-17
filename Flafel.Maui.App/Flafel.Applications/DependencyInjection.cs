using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Flafel.Applications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServieces(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IPasswordHasher<object>, PasswordHasher<object>>();

            return services;
        }
    }
}
