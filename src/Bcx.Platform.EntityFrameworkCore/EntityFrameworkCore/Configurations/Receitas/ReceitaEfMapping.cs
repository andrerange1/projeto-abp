using Bcx.Platform.Receitas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.Receitas
{
    public class ReceitaEfMapping : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ToTable("receitas");
            
            builder.ConfigureByConvention();

            builder.HasOne(p => p.Autor)
                .WithMany()
                .HasForeignKey(p => p.AutorId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(p => p.Ingredientes)
                .WithOne(x => x.Receita)
                .HasForeignKey(x => x.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Fotos)
                .WithOne()
                .HasForeignKey(f => f.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => new { p.AutorId, p.Titulo })
                .HasDatabaseName("idx_search_receita");
        }
    }
}