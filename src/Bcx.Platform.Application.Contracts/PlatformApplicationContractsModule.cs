using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform
{
    [DependsOn(
        typeof(PlatformDomainSharedModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class PlatformApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PlatformDtoExtensions.Configure();

            LimitedResultRequestDto.MaxMaxResultCount = int.MaxValue;
            LimitedResultRequestDto.DefaultMaxResultCount = int.MaxValue;
        }
    }
}
