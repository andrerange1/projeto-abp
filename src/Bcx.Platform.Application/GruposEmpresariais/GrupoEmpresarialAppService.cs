using Bcx.Platform.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace Bcx.Platform.GruposEmpresariais
{
    [Authorize(SecurityPermissions.GrupoEmpresarial.Default)]
    public class GrupoEmpresarialAppService : CrudAppService<GrupoEmpresarial, GrupoEmpresarialDto, Guid, GetAllGrupoEmpresarialDto, GrupoEmpresarialCreateUpdateDto>, IGrupoEmpresarialAppService
    {
        protected override string GetPolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Default;
        protected override string GetListPolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Default;
        protected override string CreatePolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Criar;
        protected override string UpdatePolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Alterar;
        protected override string DeletePolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Remover;

        public GrupoEmpresarialAppService(IRepository<GrupoEmpresarial, Guid> repository) : base(repository)
        {
        }

        [Obsolete]
        protected override IQueryable<GrupoEmpresarial> CreateFilteredQuery(GetAllGrupoEmpresarialDto input)
        {
            var repo = Repository.AsQueryable();

            //public bool? WithEmpresas { get; set; }
            if (input?.WithEmpresas == true)
            {
                repo = Repository.WithDetails(q => q.Empresas);
            }

            return repo
                //public string Search { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.Search),
                    q => q.Nome.ToLowerInvariant().Contains(input.Search.ToLowerInvariant())
                         || q.Empresas.Any(c =>
                                c.Nome.ToLowerInvariant().Contains(input.Search.ToLowerInvariant())
                                || c.RazaoSocial.ToLowerInvariant().Contains(input.Search.ToLowerInvariant())))

                //public string Nome { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.Search),
                    q => q.Nome.ToLowerInvariant().Contains(input.Search.ToLowerInvariant()))

                //public Guid? TenantId { get; set; }
                .WhereIf(input.TenantId.HasValue,
                    q => q.TenantId == input.TenantId)

                //public string RaizCnpj { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.RaizCnpj),
                    q => q.Empresas.Any(e => e.Cnpj.StartsWith(input.RaizCnpj.Trim())));
  
        }

        public async override Task<GrupoEmpresarialDto> CreateAsync(GrupoEmpresarialCreateUpdateDto input)
        {
            await ValidateGrupoEmpresarialNameIsUnique(input.Nome);
            return await base.CreateAsync(input);
        }

        public async override Task<GrupoEmpresarialDto> UpdateAsync(Guid id, GrupoEmpresarialCreateUpdateDto input)
        {
            await ValidateGrupoEmpresarialNameIsUnique(input.Nome);
            return await base.UpdateAsync(id, input);
        }

        private async Task ValidateGrupoEmpresarialNameIsUnique(string name)
        {
            bool existsOtherWithSameName = await Repository.AnyAsync(x => x.Nome.Equals(name));
            if (existsOtherWithSameName)
            {
                throw new AbpValidationException(
                    "Nome do Grupo Empresarial inválido!",
                    new List<ValidationResult>
                    {
                        new ValidationResult("Já existe outro grupo empresarial com o mesmo nome!")
                    }
                );
            }
        }
    }
}
