using System;
using System.Threading.Tasks;
using EasyCompiler.Infra.Data.Context;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCompiler.Infra.CrossCutting.Extensions
{
    public static class EntityFramework
    {
        public static async Task<IServiceProvider> MigrateContextDbAsync(this IServiceProvider serviceProvider)
        {
            using var escope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();

            var contextDb = escope.ServiceProvider.GetRequiredService<EasyCompilerContext>();

            if (!(contextDb is null))
            {
                await contextDb.Database.MigrateAsync();
            }

            return serviceProvider;
        }
    }
}
