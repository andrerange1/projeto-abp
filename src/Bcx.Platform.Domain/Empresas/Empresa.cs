using Bcx.Platform.GruposEmpresariais;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bcx.Platform.Empresas
{
    public class Empresa : AuditedEntity<Guid>
    {
        [MaxLength(EmpresaConsts.CnpjMaxLength, ErrorMessage = SecurityDomainErrorCodes.EmpresaCnpjDeveTer14Digitos)]
        [Required(ErrorMessage = SecurityDomainErrorCodes.EmpresaCnpjRequerido)]
        public string Cnpj { get; set; }

        public Guid? GrupoEmpresarialId { get; set; }

        public GrupoEmpresarial GrupoEmpresarial { get; set; }

        [Required(ErrorMessage = SecurityDomainErrorCodes.EmpresaRazaoSocialRequerido)]
        public string RazaoSocial { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; } = true;

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }
    }
}
