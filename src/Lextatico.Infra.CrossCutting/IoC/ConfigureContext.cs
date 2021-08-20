using Lextatico.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lextatico.Infra.CrossCutting.IoC
{
    public static class ConfigureContext
    {
        public static void AddContext(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContext<LextaticoContext>(op =>
            {
                var sqlStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString(nameof(LextaticoContext)));

                sqlStringBuilder.Password = configuration["DbPassword"];

                var connectionString = sqlStringBuilder.ToString();

                op.UseSqlServer(connectionString);
            });
        }
    }
}
