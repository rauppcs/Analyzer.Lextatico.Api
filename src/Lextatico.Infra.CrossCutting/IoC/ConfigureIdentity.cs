using Lextatico.Infra.Data.Context;
using Lextatico.Infra.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureIdentity
    {
        public static IServiceCollection AddLextaticoIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<LextaticoContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
