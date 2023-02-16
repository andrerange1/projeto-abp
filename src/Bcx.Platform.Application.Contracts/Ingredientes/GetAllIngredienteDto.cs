using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Ingredientes
{
    public class GetAllIngredienteDto : PagedAndSortedResultRequestDto
    {
        public string Search { get; set; }
    }
}
