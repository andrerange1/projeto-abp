using Bcx.Platform.Users;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform.UserTenants
{
    public class UserTenant : AuditedEntity
    {
        [Required(ErrorMessage = SecurityDomainErrorCodes.UserTenantUserRequired)]
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required(ErrorMessage = SecurityDomainErrorCodes.UserTenantTenantRequired)]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { this.UserId, this.TenantId };
        }
    }
}
