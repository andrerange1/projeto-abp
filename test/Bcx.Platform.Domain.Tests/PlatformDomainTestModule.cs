using Bcx.Platform.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bcx.Platform
{
    [DependsOn(
        typeof(PlatformEntityFrameworkCoreTestModule)
        )]
    public class PlatformDomainTestModule : AbpModule
    {

    }
}