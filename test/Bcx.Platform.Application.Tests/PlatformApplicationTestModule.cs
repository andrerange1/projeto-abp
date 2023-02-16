using Volo.Abp.Modularity;

namespace Bcx.Platform
{
    [DependsOn(
        typeof(PlatformApplicationModule),
        typeof(PlatformDomainTestModule)
        )]
    public class PlatformApplicationTestModule : AbpModule
    {

    }
}