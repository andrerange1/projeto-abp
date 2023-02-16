using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bcx.Platform.Ingredientes
{
    public class CreateUpdateIngredienteDto
    {
        [MaxLength(IngredienteConsts.MaxIconeLength, ErrorMessage = IngredienteConsts.IngredienteIconeMaxLength)]
        public string Icone { get; set; }

        [MaxLength(IngredienteConsts.MaxNomeLength, ErrorMessage = IngredienteConsts.IngredienteNomeMaxLength)]
        public string Nome { get; set; }
    }
}
