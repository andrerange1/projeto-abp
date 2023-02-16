using Bcx.Platform.GruposEmpresariais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.EntityFrameworkCore.Configurations.GruposEmpresariais
{
    public class GrupoEmpresarialEfConfiguration : IEntityTypeConfiguration<GrupoEmpresarial>
    {
        private readonly SecurityBuilderConfigurationOptions _options;

        public GrupoEmpresarialEfConfiguration(SecurityBuilderConfigurationOptions options)
        {
            _options = options;
        }

        public void Configure(EntityTypeBuilder<GrupoEmpresarial> builder)
        {
            builder.ToTable(_options.DbTablePrefix + "GruposEmpresariais", _options.DbSchema);
            builder.ConfigureByConvention();

            // Properties
            builder.Property(p => p.Nome)
                .IsRequired();

            // Foreign Keys
            builder.HasOne(p => p.Tenant)
                .WithMany()
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Empresas)
                .WithOne(p => p.GrupoEmpresarial)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(p => new { p.TenantId, p.Nome })
                .HasDatabaseName("bcx_platform_grupoempresarial_search_none");
        }
    }
}
