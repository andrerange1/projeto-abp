using Bcx.Platform.Ingredientes;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Receita2Ingredientes
{
    public class Receita2IngredienteDto : EntityDto
    {
        public int IngredienteId { get; set; }
        public IngredienteDto Ingrediente { get; set; }

        public int ReceitaId { get; set; }
        public double Quantidade { get; set; }

        public string Unidade { get; set; }
    }
}
