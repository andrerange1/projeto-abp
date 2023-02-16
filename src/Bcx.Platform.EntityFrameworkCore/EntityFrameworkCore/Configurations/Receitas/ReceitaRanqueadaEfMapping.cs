using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bcx.Platform.Receitas
{
    public class ReceitaRanqueadaEfMapping : IEntityTypeConfiguration<ReceitaRanqueada>
    {
        public const string ViewName = "vw_receita_ranqueada";

        public void Configure(EntityTypeBuilder<ReceitaRanqueada> builder)
        {

            Check.NotNull(builder, nameof(builder));

            builder.ToView(ViewName);
            builder.ConfigureByConvention();
            builder.HasNoKey();
        }
    }
}
