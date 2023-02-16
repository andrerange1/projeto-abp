using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.ReceitaFotos
{
    public class ReceitaFotoEfMapping : IEntityTypeConfiguration<ReceitaFoto>
    {
        public void Configure(EntityTypeBuilder<ReceitaFoto> builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ToTable("receita_foto");

            builder.ConfigureByConvention();

            builder.HasIndex(p => new { p.ReceitaId, p.Default })
                .IsUnique()
                .HasDatabaseName("idx_receita_somente_uma_foto_default")
                .HasFilter($"\"Default\" = (TRUE)");
        }
    }
}
