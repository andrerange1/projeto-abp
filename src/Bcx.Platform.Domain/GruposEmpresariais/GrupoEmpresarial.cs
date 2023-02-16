using Bcx.Platform.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform.GruposEmpresariais
{
    public class GrupoEmpresarial : AuditedEntity<Guid>, IMultiTenant
    {
        [Required(ErrorMessage = SecurityDomainErrorCodes.GrupoEmpresarialNameRequired)]
        public string Nome { get; set; }

        public Guid? TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}
