using Bcx.Platform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Bcx.Platform.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PlatformEntityFrameworkCoreDbMigrationsModule),
        typeof(PlatformApplicationContractsModule)
        )]
    public class PlatformDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
