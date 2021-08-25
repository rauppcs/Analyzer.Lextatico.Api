using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Lextatico.Infra.CrossCutting.Configurations;

namespace Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureControllers
    {
        public static IServiceCollection AddLextaticoControllers(this IServiceCollection services, Action<ApiBehaviorOptions> configure)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new UrlPatterner()));
            })
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
