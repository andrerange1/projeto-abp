using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Empresas
{
    public class EmpresaDto : EntityDto<Guid>
    {
        public string Cnpj { get; set; }

        public Guid GrupoEmpresarialId { get; set; }

        public string GrupoEmpresarialNome { get; set; }

        public string RazaoSocial { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }
    }
}
