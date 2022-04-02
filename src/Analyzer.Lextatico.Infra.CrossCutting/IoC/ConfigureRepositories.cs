using Analyzer.Lextatico.Domain.Interfaces.Repositories;
using Analyzer.Lextatico.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Analyzer.Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureRepositories
    {
        public static IServiceCollection AddLextaticoRepositories(this IServiceCollection services)
        {
            // REPOSITORIES
            services.AddScoped<IAnalyzerRepository, AnalyzerRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ITerminalTokenRepository, TerminalTokenRepository>();

            return services;
        }
    }
}
