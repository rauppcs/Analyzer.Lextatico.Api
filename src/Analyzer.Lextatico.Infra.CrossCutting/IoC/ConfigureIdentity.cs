using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Analyzer.Lextatico.Infra.Data.Context;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Infra.Identity.Extensions;

namespace Analyzer.Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureIdentity
    {
        public static IServiceCollection AddLextaticoIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
                .AddEntityFrameworkStores<LextaticoContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
