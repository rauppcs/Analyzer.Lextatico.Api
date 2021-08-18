using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyCompiler.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<EasyCompilerContext>
    {
        /// <summary>
        /// Used for migrations
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Returns a valid DbContext.</returns>
        public EasyCompilerContext CreateDbContext(string[] args)
        {
            if (Debugger.IsAttached == false)
            {
                Debugger.Launch();
            }

            var directory = Directory.GetParent(Directory.GetCurrentDirectory())
                .GetDirectories("EasyCompiler.Api").FirstOrDefault().FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.LocalDevelopment.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(Assembly.Load("EasyCompiler.Infra.Data"))
                .Build();

            var sqlStringBuilder = new SqlConnectionStringBuilder(builder.GetConnectionString(nameof(EasyCompilerContext)));

            sqlStringBuilder.Password = builder["DbPassword"];

            var connectionString = sqlStringBuilder.ToString();

            var optionsBuilder = new DbContextOptionsBuilder<EasyCompilerContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new EasyCompilerContext(optionsBuilder.Options);
        }
    }
}
