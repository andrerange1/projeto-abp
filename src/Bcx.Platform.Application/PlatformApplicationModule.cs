using Bcx.Platform.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Authorization;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform
{
    [DependsOn(
        typeof(PlatformDomainModule),
        typeof(PlatformApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class PlatformApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PlatformApplicationModule>();
            });

            context.Services.Replace(new ServiceDescriptor(
                typeof(IMethodInvocationAuthorizationService),
                typeof(HostOnlyMethodInvocationAuthorizationService),
                ServiceLifetime.Transient));
        }
    }
}
