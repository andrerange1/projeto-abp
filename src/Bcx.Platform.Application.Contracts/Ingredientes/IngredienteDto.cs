using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Ingredientes
{
    public class IngredienteDto : EntityDto<int>
    {
        [MaxLength(IngredienteConsts.MaxIconeLength, ErrorMessage = IngredienteConsts.IngredienteIconeMaxLength)]
        public string Icone { get; set; }

        [MaxLength(IngredienteConsts.MaxNomeLength, ErrorMessage = IngredienteConsts.IngredienteNomeMaxLength)]
        public string Nome { get; set; }
    }
}
