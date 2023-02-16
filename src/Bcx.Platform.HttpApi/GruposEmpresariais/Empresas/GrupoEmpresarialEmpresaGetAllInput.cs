using Bcx.Platform.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcx.Platform.GruposEmpresariais.Empresas
{
    public class GrupoEmpresarialEmpresaGetAllInput
    {
        public string Search { get; set; }

        [MaxLength(EmpresaConsts.CnpjMaxLength, ErrorMessage = SecurityDomainErrorCodes.EmpresaCnpjDeveTer14Digitos)]
        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string Nome { get; set; }

        public bool? Ativo { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }
    }
}
