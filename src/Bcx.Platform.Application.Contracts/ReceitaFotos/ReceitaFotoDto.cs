using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.ReceitaFotos
{
    public class ReceitaFotoDto : EntityDto
    {
        public int Id { get; set; }
        public int ReceitaId { get; set; }
        public bool Default { get; set; } = false;
        public string Uri { get; set; }
    }
}
