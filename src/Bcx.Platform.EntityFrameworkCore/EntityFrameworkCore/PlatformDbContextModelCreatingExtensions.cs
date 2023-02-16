using Bcx.Platform.Ingredientes;
using Bcx.Platform.Rating;
using Bcx.Platform.Receita2Ingredientes;
using Bcx.Platform.ReceitaFotos;
using Bcx.Platform.Receitas;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Bcx.Platform.EntityFrameworkCore
{
    public static class PlatformDbContextModelCreatingExtensions
    {
        public static void ConfigurePlatform(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(PlatformConsts.DbTablePrefix + "YourEntities", PlatformConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.ApplyConfiguration(new IngredienteEfMapping());
            builder.ApplyConfiguration(new RatingEfMapping());
            builder.ApplyConfiguration(new Receita2IngredienteEfMapping());
            builder.ApplyConfiguration(new ReceitaFotoEfMapping());
            builder.ApplyConfiguration(new ReceitaEfMapping());
            builder.ApplyConfiguration(new ReceitaRanqueadaEfMapping());
        }

    }
}