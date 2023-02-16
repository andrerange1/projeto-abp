using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Receitas
{
    public class GetAllReceitaDto : PagedAndSortedResultRequestDto
    {
        public string Search { get; set; }

        public Guid? ByAuthorId { get; set; }

        public string ByAuthorName { get; set; }

        public IEnumerable<int> WithIngredientes { get; set; } = new List<int>();
    }
}
