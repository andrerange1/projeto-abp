using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Bcx.Platform.EntityFrameworkCore
{
    [DependsOn(
        typeof(PlatformEntityFrameworkCoreModule)
        )]
    public class PlatformEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PlatformMigrationsDbContext>();
        }
    }
}
