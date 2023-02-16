using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Bcx.Platform.Ingredientes
{
    public class Ingrediente : Entity<int>
    {
        [MaxLength(IngredienteConsts.MaxIconeLength, ErrorMessage = IngredienteConsts.IngredienteIconeMaxLength)]
        public string Icone { get; set; }

        [MaxLength(IngredienteConsts.MaxNomeLength, ErrorMessage = IngredienteConsts.IngredienteNomeMaxLength)]
        public string Nome { get; set; }
    }
}
