using Bcx.Platform.Ingredientes;
using Bcx.Platform.Receitas;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Bcx.Platform.Receita2Ingredientes
{
    public class Receita2Ingrediente : Entity
    {
        [Required(ErrorMessage = Receita2IngredienteConsts.IngredienteIdIsRequired)]
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }

        [Required(ErrorMessage = Receita2IngredienteConsts.ReceitaIdIsRequired)]
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }

        [Required(ErrorMessage = Receita2IngredienteConsts.QuantidadeIsRequired)]
        [Range(Receita2IngredienteConsts.QuantidadeRangeStart, Receita2IngredienteConsts.QuantidadeRangeEnd, ErrorMessage = Receita2IngredienteConsts.QuantidadeOutOfRange)]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = Receita2IngredienteConsts.UnidadeIsRequired)]
        [MaxLength(Receita2IngredienteConsts.UnidadeMaxLength, ErrorMessage = Receita2IngredienteConsts.UnidadeLessThenMaxLength)]
        public string Unidade { get; set; }

        public override object[] GetKeys()
            => new object[]
            {
                IngredienteId,
                ReceitaId
            };
    }
}
