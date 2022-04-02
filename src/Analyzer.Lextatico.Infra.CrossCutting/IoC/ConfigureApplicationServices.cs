using Analyzer.Lextatico.Application.Services;
using Analyzer.Lextatico.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Analyzer.Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddLextaticoApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAnalyzerAppService, AnalyzerAppService>();
            services.AddScoped<ITerminalTokenAppService, TerminalTokenAppService>();

            return services;
        }
    }
}
