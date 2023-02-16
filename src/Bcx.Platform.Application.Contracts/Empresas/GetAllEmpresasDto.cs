﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Empresas
{
    public class GetAllEmpresasDto : PagedAndSortedResultRequestDto
    {
        public string Search { get; set; }

        [MaxLength(EmpresaConsts.CnpjMaxLength, ErrorMessage = SecurityDomainErrorCodes.EmpresaCnpjDeveTer14Digitos)]
        public string Cnpj { get; set; }

        public virtual Guid? GrupoEmpresarialId { get; set; }

        public string RazaoSocial { get; set; }

        public string Nome { get; set; }

        public bool? Ativo { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }
    }
}
