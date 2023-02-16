using Bcx.Platform.Receita2Ingredientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.Receita2Ingredientes
{
    public class Receita2IngredienteEfMapping : IEntityTypeConfiguration<Receita2Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Receita2Ingrediente> builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ToTable("receita2ingredientes");
            builder.HasKey(p => new { p.ReceitaId, p.IngredienteId });

            builder.Property(p => p.Unidade)
                .HasMaxLength(Receita2IngredienteConsts.UnidadeMaxLength);

            // Foreign Keys
            builder.HasOne(p => p.Receita)
                .WithMany()
                .HasForeignKey(p => p.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Ingrediente)
                .WithMany()
                .HasForeignKey(p => p.IngredienteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ConfigureByConvention();
        }
    }
}
