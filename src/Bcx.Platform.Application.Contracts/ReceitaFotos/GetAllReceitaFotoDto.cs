using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.ReceitaFotos
{
    public class GetAllReceitaFotoDto : PagedAndSortedResultRequestDto
    {
        public int ReceitaId { get; set; }
        public bool? IsDefault { get; set; }
    }
}
