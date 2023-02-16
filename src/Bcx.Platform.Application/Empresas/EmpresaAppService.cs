using Bcx.Platform.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.Empresas
{
    [Authorize(SecurityPermissions.Empresas.Default)]
    public class EmpresaAppService : CrudAppService<Empresa, EmpresaDto, Guid, GetAllEmpresasDto, EmpresaCreateUpdateDto>, IEmpresaAppService
    {
        protected override string GetPolicyName { get; set; } = SecurityPermissions.Empresas.Default;
        protected override string GetListPolicyName { get; set; } = SecurityPermissions.Empresas.Default;
        protected override string CreatePolicyName { get; set; } = SecurityPermissions.Empresas.Criar;
        protected override string UpdatePolicyName { get; set; } = SecurityPermissions.Empresas.Alterar;
        protected override string DeletePolicyName { get; set; } = SecurityPermissions.Empresas.Remover;

        public EmpresaAppService(IRepository<Empresa, Guid> repository) : base(repository)
        {
        }
        
        [Obsolete]
        protected override IQueryable<Empresa> CreateFilteredQuery(GetAllEmpresasDto input)
        {
            return Repository
                .WithDetails(q => q.GrupoEmpresarial)

                // public string Search {get; set;}
                .WhereIf(!string.IsNullOrWhiteSpace(input.Search),
                    q => q.Nome
                        .ToUpperInvariant()
                        .Contains(input.Search.Trim().ToUpperInvariant())
                        || q.RazaoSocial
                        .ToUpperInvariant()
                        .Contains(input.Search.ToUpperInvariant())
                        || q.Cnpj.StartsWith(input.Search))

                //public string Cnpj { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.Cnpj),
                    q => q.Cnpj.StartsWith(input.Cnpj))

                //public int? GrupoEmpresarialId { get; set; }
                .WhereIf(input.GrupoEmpresarialId.HasValue,
                    q => q.GrupoEmpresarialId == input.GrupoEmpresarialId)

                //public string RazaoSocial { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.RazaoSocial),
                    q => q.RazaoSocial
                        .ToUpperInvariant()
                        .Contains(input.RazaoSocial.Trim().ToUpperInvariant()))

                //public string Nome { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.Nome),
                    q => q.Nome
                        .ToUpperInvariant()
                        .Contains(input.Nome.Trim().ToUpperInvariant()))

                //public bool? Ativo { get; set; }
                .WhereIf(input.Ativo.HasValue,
                    q => q.Ativo == input.Ativo)

                //public string InscricaoEstadual { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.InscricaoEstadual),
                    q => q.InscricaoEstadual
                        .StartsWith(input.InscricaoEstadual.Trim()))

                //public string InscricaoMunicipal { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.InscricaoMunicipal),
                    q => q.InscricaoMunicipal
                        .StartsWith(input.InscricaoMunicipal.Trim()));
        }

    }
}
