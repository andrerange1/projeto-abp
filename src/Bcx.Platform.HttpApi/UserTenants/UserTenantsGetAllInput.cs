using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.UserTenants
{

    public class UserTenantsGetAllInput : PagedAndSortedResultRequestDto
    {
        public string SearchByTenant { get; set; }
        public string SearchByUser { get; set; }

        public IEnumerable<Guid> TenantIds { get; set; } = new List<Guid>();
    }
}
