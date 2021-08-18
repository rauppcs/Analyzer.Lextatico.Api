using System.Threading.Tasks;
using EasyCompiler.Infra.CrossCutting.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyCompiler.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var webHostEnvironment = host.Services.GetRequiredService<IWebHostEnvironment>();

            await host.Services.MigrateContextDbAsync(webHostEnvironment.IsProduction());

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
