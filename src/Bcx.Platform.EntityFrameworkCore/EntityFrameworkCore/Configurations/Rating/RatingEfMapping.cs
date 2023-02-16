using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.Rating
{
    public class RatingEfMapping : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ToTable("rating");

            builder.HasKey(p => new { p.ReceitaId, p.UserId });

            builder.HasOne(p => p.Receita)
                .WithMany()
                .HasForeignKey(p => p.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ConfigureByConvention();
        }
    }
}
