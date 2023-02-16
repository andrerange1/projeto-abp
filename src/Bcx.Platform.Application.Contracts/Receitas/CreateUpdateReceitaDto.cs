using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform.Receitas
{
    public class CreateUpdateReceitaDto
    {
        public Guid AutorId { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
