using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bcx.Platform.UserTenants
{
    public class CreateUpdateUserTenantDto
    {
        [Required(ErrorMessage = SecurityDomainErrorCodes.UserTenantUserRequired)]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = SecurityDomainErrorCodes.UserTenantTenantRequired)]
        public Guid TenantId { get; set; }
    }
}
