using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform.ReceitaFotos
{
    public class CreateUpdateReceitaFotoDto
    {
        public int ReceitaId { get; set; }
        public bool Default { get; set; } = false;
        public string Uri { get; set; }
    }
}
