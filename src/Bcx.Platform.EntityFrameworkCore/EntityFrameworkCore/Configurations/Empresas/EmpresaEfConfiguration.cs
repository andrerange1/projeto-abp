using Bcx.Platform.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.EntityFrameworkCore.Configurations.Empresas
{
    public class EmpresaEfConfiguration : IEntityTypeConfiguration<Empresa>
    {
        private readonly SecurityBuilderConfigurationOptions _options;

        public EmpresaEfConfiguration(SecurityBuilderConfigurationOptions options)
        {
            _options = options;
        }

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ToTable(_options.DbTablePrefix + "Empresa", _options.DbSchema);

            builder.ConfigureByConvention(); //auto configure for the base class props

            // Properties
            builder.Property(p => p.Cnpj)
                .HasMaxLength(EmpresaConsts.CnpjMaxLength)
                .IsRequired();

            builder.Property(p => p.RazaoSocial)
                .IsRequired();

            // Foreign Keys
            builder.HasOne(p => p.GrupoEmpresarial)
                .WithMany(g => g.Empresas)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(p => p.Cnpj)
                .HasDatabaseName("bcx_platform_empresa_cnpj_unique")
                .IsUnique();

            builder.HasIndex(p => p.RazaoSocial)
                .HasDatabaseName("bcx_platform_empresa_search_by_razao");

        }
    }
}
