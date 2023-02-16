using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcx.Platform.ReceitaFotos
{
    public class ReceitaFotoCreateInputDto
    {
        public bool Default { get; set; } = false;
        public string Uri { get; set; }
    }
}
