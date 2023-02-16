using Bcx.Platform.Empresas;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.GruposEmpresariais
{
    public class GrupoEmpresarialDto : AuditedEntityDto<Guid>
    {
        public string Nome { get; set; }

        public Guid? TenantId { get; set; }

        public string TenantNome { get; set; }

        public ICollection<EmpresaDto> Empresas { get; set; } = new List<EmpresaDto>();
    }
}
