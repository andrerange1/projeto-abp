using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Bcx.Platform.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See PlatformDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class PlatformMigrationsDbContext : AbpDbContext<PlatformMigrationsDbContext>
    {
        public PlatformMigrationsDbContext(DbContextOptions<PlatformMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */
            //builder.ConfigurePermissionManagement(options =>
            //{
            //    options.Schema = SecurityConsts.PermissionManagement.DbSchema;
            //    options.TablePrefix = SecurityConsts.PermissionManagement.DbTablePrefix;
            //});
            //builder.ConfigureBackgroundJobs(options =>
            //{
            //    options.Schema = SecurityConsts.BackgroundJobs.DbSchema;
            //    options.TablePrefix = SecurityConsts.BackgroundJobs.DbTablePrefix;
            //});
            //builder.ConfigureAuditLogging(options =>
            //{
            //    options.Schema = SecurityConsts.AuditLogging.DbSchema;
            //    options.TablePrefix = SecurityConsts.AuditLogging.DbTablePrefix;
            //});
            //builder.ConfigureIdentity(options => 
            //{
            //    options.Schema = SecurityConsts.Identity.DbSchema;
            //    options.TablePrefix = SecurityConsts.Identity.DbTablePrefix;
            //});
            //builder.ConfigureTenantManagement(options =>
            //{
            //    options.Schema = SecurityConsts.DbSchema;
            //    options.TablePrefix = SecurityConsts.DbTablePrefix;
            //});

            builder.ConfigurePermissionManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureTenantManagement();

            builder.ConfigureSecurity();
            builder.ConfigurePlatform();
        }
    }
}