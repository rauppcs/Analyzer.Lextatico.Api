using Analyzer.Lextatico.Api.Filters;
using Analyzer.Lextatico.Api.Options;
using Analyzer.Lextatico.Domain.Configurations;
using Analyzer.Lextatico.Domain.Security;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Analyzer.Lextatico.Api.Configurations
{
    public static class ApiConfigurations
    {
        public static IServiceCollection AddLextaticoControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                // FILTERS
                options.Filters.Add<GlobalExceptionAttribute>();
                options.Filters.Add<ValidationModelAttribute>();

                // CONVENCTIONS
                options.Conventions.Add(new RouteTokenTransformerConvention(new UrlPatterner()));
            })
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddFluentValidation(options =>
                {
                    options.DisableDataAnnotationsValidation = true;
                    options.RegisterValidatorsFromAssembly(Assembly.Load("Analyzer.Lextatico.Application"));
                });

            return services;
        }

        public static IServiceCollection AddLextaticoApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }

        public static IServiceCollection AddLexitaticoCors(this IServiceCollection services)
        {
            services.AddCors(optionsCors =>
                {
                    optionsCors.AddDefaultPolicy(optionsPolicy =>
                    {
                        optionsPolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
                });

            return services;
        }

        public static IServiceCollection AddLextaticoSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        public static WebApplication UseLextaticoSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        $"API {description.GroupName.ToUpper()}");
                }
            });

            return app;
        }

        public static IServiceCollection AddLextaticoJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var signingConfigurations = new SigningConfiguration(configuration["SecretKeyJwt"]);
            services.AddSingleton(signingConfigurations);

            var tokenConfiguration = new TokenConfiguration();
            configuration.Bind("TokenConfiguration", tokenConfiguration);

            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.RequireExpirationTime = true;
                paramsValidation.ClockSkew = TimeSpan.FromSeconds(30);
            });

            services.AddAuthorizationCore();

            return services;
        }

        public static IServiceCollection AddLextaticoUrlsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Urls>(configuration.GetSection("Urls"));

            return services;
        }
    }
}
