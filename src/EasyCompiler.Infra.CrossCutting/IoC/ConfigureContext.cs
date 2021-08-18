using System;
using EasyCompiler.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCompiler.Infra.CrossCutting.IoC
{
    public static class ConfigureContext
    {
        public static void AddContext(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContext<EasyCompilerContext>(op =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                var sqlStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString(nameof(EasyCompilerContext)));

                sqlStringBuilder.Password = configuration["DbPassword"];

                var connectionString = sqlStringBuilder.ToString();

                op.UseSqlServer(connectionString);
            });
        }
    }
}
