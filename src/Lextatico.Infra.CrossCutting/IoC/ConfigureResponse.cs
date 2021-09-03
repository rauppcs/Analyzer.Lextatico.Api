using Lextatico.Domain.Dtos.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureResponse
    {
        public static IServiceCollection AddResponse(this IServiceCollection services)
        {
            services.AddScoped<IResponse, Response>();

            return services;
        }
    }
}