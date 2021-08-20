using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureSwagger
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("doc",
                     new OpenApiInfo
                     {
                         Title = "Lextatico Api",
                         Version = "v1",
                         Contact = new OpenApiContact{
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
        }
    }
}
