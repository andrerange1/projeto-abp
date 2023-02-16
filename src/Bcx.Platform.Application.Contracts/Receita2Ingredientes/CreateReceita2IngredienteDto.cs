using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform.Receita2Ingredientes
{
    public class CreateReceita2IngredienteDto
    {
        public int IngredienteId { get; set; }

        public int ReceitaId { get; set; }
        public double Quantidade { get; set; }

        public string Unidade { get; set; }
    }
}
