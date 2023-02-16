using Bcx.Platform.UserTenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.EntityFrameworkCore.Configurations.UserTenants
{
    public class UserTenantEfConfiguration : IEntityTypeConfiguration<UserTenant>
    {
        private readonly SecurityBuilderConfigurationOptions _options;
        public UserTenantEfConfiguration(SecurityBuilderConfigurationOptions options)
        {
            _options = options;
        }

        public void Configure(EntityTypeBuilder<UserTenant> builder)
        {
            builder.ToTable(_options.DbTablePrefix + "UserTenants", _options.DbSchema);
            builder.ConfigureByConvention();
            builder.HasKey(p => new { p.TenantId, p.UserId });

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Tenant)
                .WithMany()
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
