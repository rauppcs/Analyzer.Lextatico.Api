using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureControllers
    {
        public static IServiceCollection AddLextaticoControllers(this IServiceCollection services, Action<ApiBehaviorOptions> configure)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(configure)
                .AddFluentValidation(options =>
                {
                    options.DisableDataAnnotationsValidation = true;
                    options.RegisterValidatorsFromAssembly(Assembly.Load("Lextatico.Application"));
                });

            return services;
        }
    }
}
