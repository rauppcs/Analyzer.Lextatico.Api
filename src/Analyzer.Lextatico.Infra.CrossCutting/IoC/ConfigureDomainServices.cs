using Analyzer.Lextatico.Domain.Interfaces.Services;
using Analyzer.Lextatico.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Analyzer.Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureDomainServices
    {
        public static IServiceCollection AddLextaticoDomainServices(this IServiceCollection services)
        {
            // DOMAIN SERVICES
            services.AddScoped<IAnalyzerService, AnalyzerService>();
            services.AddScoped<ITerminalTokenService, TerminalTokenService>();

            return services;
        }
    }
}
