 using Microsoft.AspNetCore.Builder;
using Bcx.Platform.EntityFrameworkCore;
using Bcx.Platform.MultiTenancy;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.BackgroundJobs;
using Bcx.Platform.Security;
using Bcx.Platform.Platform;

namespace Bcx.Platform
{
    [DependsOn(
        typeof(PlatformHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(PlatformApplicationModule),
        typeof(PlatformEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
    )]
    public class PlatformHttpApiHostModule : AbpModule
    {


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services
                .AddPlatformAuthentication()
                .AddPlatformAuthorization()
                .AddDisableAbpAntiForgery()
                .AddApiExceptions()
                .AddPlatformCorsConfiguration()
                .AddPlatformSwagger()
                .AddPlatformConventionalControllers(typeof(PlatformApplicationModule));

            ConfigureBackgroundJobs();
        }

        private void ConfigureBackgroundJobs()
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }


        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(PlatformCorsOptions.DefaultCorsPolicyName);
            app.UseAuthentication();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
                app.UseChangeTenant();
            }

            app.UsePlatformAuthorization();
            app.UsePlatformSwagger();

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseUnitOfWork();
            app.UseConfiguredEndpoints();
        }
    }
}
