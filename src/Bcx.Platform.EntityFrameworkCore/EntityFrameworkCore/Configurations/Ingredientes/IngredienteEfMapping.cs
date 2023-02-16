using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.Ingredientes
{
    public class IngredienteEfMapping : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ToTable("ingrediente");

            builder.ConfigureByConvention();

            builder.Property(x => x.Icone)
                .HasMaxLength(IngredienteConsts.MaxIconeLength)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(IngredienteConsts.MaxNomeLength)
                .IsRequired();

            builder.HasIndex(p => p.Nome)
                .IsUnique()
                .HasDatabaseName("idx_ingrediente_nome_unique");

        }
    }
}
