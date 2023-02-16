using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.GruposEmpresariais
{
    public class GetAllGrupoEmpresarialDto : PagedAndSortedResultRequestDto
    {
        public string Search { get; set; }

        public string Nome { get; set; }
        
        public Guid? TenantId { get; set; }
        
        [MaxLength(GrupoEmpresarialConsts.RaizCnpjMaxLength, ErrorMessage = SecurityDomainErrorCodes.RaizCnpjNaoDeveUltrapassar8Digitos)]
        public string RaizCnpj { get; set; }

        public bool? WithEmpresas { get; set; }
    }
}
