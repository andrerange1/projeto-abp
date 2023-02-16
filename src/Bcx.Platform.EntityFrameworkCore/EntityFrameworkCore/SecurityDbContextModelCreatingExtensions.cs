using Bcx.Platform.EntityFrameworkCore.Configurations.Empresas;
using Bcx.Platform.EntityFrameworkCore.Configurations.GruposEmpresariais;
using Bcx.Platform.EntityFrameworkCore.Configurations.UserTenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform.EntityFrameworkCore
{
    public static class SecurityDbContextModelCreatingExtensions
    {
        //public static void ConfigureAbpUserSecurityProperties<TUser>(this EntityTypeBuilder<TUser> b)
        //    where TUser : class, IUser
        //{
        //    // b.Property<Guid?>(nameof(AppUser.Tenants));
        //    b.HasMany<UserTenant>(nameof(AppUser.Tenants))
        //        .WithOne()
        //        .HasForeignKey(u => u.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

        public static void ConfigurePlatformSchemas(this IServiceCollection builder)
        {
            AbpPermissionManagementDbProperties.DbSchema = "security";
            AbpPermissionManagementDbProperties.DbTablePrefix = "";
            BackgroundJobsDbProperties.DbSchema = "jobs";
            BackgroundJobsDbProperties.DbTablePrefix = "";
            AbpAuditLoggingDbProperties.DbSchema = "logs";
            AbpAuditLoggingDbProperties.DbTablePrefix = "";
            AbpIdentityDbProperties.DbSchema = "identity";
            AbpIdentityDbProperties.DbTablePrefix = "";
            AbpTenantManagementDbProperties.DbSchema = "security";
            AbpTenantManagementDbProperties.DbTablePrefix = "";
        }

        public static void ConfigureSecurity(this ModelBuilder builder, Action<SecurityBuilderConfigurationOptions> options = default)
        {
            Check.NotNull(builder, nameof(builder));

            var settings = new SecurityBuilderConfigurationOptions();
            options?.Invoke(settings);

            /* Configure your own tables/entities inside here */
            builder
                .ApplyConfiguration(new EmpresaEfConfiguration(settings))
                .ApplyConfiguration(new GrupoEmpresarialEfConfiguration(settings))
                .ApplyConfiguration(new UserTenantEfConfiguration(settings));

        }
    }
}
