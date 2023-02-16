using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bcx.Platform.Empresas
{
    public class EmpresaCreateUpdateDto
    {
        [MaxLength(EmpresaConsts.CnpjMaxLength, ErrorMessage = SecurityDomainErrorCodes.EmpresaCnpjDeveTer14Digitos)]
        [Required(ErrorMessage = SecurityDomainErrorCodes.EmpresaCnpjRequerido)]
        public string Cnpj { get; set; }

        public Guid? GrupoEmpresarialId { get; set; }

        [Required(ErrorMessage = SecurityDomainErrorCodes.EmpresaRazaoSocialRequerido)]
        public string RazaoSocial { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }
    }
}
