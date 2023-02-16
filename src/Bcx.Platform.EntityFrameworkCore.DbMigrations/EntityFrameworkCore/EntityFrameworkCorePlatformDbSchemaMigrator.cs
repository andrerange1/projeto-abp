using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bcx.Platform.Data;
using Volo.Abp.DependencyInjection;

namespace Bcx.Platform.EntityFrameworkCore
{
    public class EntityFrameworkCorePlatformDbSchemaMigrator
        : IPlatformDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePlatformDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the PlatformMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<PlatformMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}