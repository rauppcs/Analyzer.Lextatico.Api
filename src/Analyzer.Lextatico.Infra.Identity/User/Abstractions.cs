using Microsoft.Extensions.DependencyInjection;

namespace Analyzer.Lextatico.Infra.Identity.User
{
    public static class Abstractions
    {
        public static IServiceCollection AddLextaticoAspNetUserConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}
