using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bcx.Platform.GruposEmpresariais
{
    public class GrupoEmpresarialCreateUpdateDto
    {
        [Required(ErrorMessage = SecurityDomainErrorCodes.GrupoEmpresarialNameRequired)]
        public string Nome { get; set; }

        public Guid? TenantId { get; set; }
    }
}
