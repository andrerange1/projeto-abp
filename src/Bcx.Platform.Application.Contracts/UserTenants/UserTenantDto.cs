using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.UserTenants
{
    public class UserTenantDto : EntityDto
    {
        [Required(ErrorMessage = SecurityDomainErrorCodes.UserTenantUserRequired)]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = SecurityDomainErrorCodes.UserTenantTenantRequired)]
        public Guid TenantId { get; set; }

        public string TenantName { get; set; }
    }
}
