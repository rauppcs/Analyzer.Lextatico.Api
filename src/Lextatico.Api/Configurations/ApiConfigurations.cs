using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using Lextatico.Domain.Configurations;
using Lextatico.Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Lextatico.Api.Configurations
{
    public static class ApiConfigurations
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

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("doc",
                     new OpenApiInfo
                     {
                         Title = "Lextatico Api",
                         Version = "v1",
                         Contact = new OpenApiContact
                         {
                             Name = "Cassiano dos Santos Raupp",
                             Url = new Uri("https://www.linkedin.com/in/cassiano-raupp-50a6a9133/")
                         }
                     });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
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

            services.AddAuthorizationCore(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }

        public static IServiceCollection AddUrlsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Urls>(configuration.GetSection("Urls"));

            return services;
        }
    }
}
