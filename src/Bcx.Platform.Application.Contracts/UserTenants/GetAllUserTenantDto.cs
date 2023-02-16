using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.UserTenants
{
    public class GetAllUserTenantDto : PagedAndSortedResultRequestDto
    {
        public string SearchByTenant { get; set; }
        public string SearchByUser { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TenantId { get; set; }

        public IEnumerable<Guid> TenantIds { get; set; } = new List<Guid>();
    }
}
