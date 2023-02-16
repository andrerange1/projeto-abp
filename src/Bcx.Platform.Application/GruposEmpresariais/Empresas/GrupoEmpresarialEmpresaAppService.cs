using Bcx.Platform.Empresas;
using Bcx.Platform.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.GruposEmpresariais.Empresas
{
    [RemoteService(false)]
    [Authorize(SecurityPermissions.GrupoEmpresarial.Default)]
    public class GrupoEmpresarialEmpresaAppService :
        AbstractKeyReadOnlyAppService<Empresa, EmpresaDto, CreateGrupoEmpresarialEmpresaKeysDto, GetAllGrupoEmpresarialEmpresaDto>,
        IGrupoEmpresarialEmpresaAppService
    {
        protected override string GetPolicyName { get; set; } = SecurityPermissions.Empresas.Default;
        protected override string GetListPolicyName { get; set; } = SecurityPermissions.Empresas.Default;
        protected string CreatePolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Alterar;
        protected string DeletePolicyName { get; set; } = SecurityPermissions.GrupoEmpresarial.Alterar;

        private readonly IRepository<Empresa, Guid> Repository;

        public GrupoEmpresarialEmpresaAppService(IRepository<Empresa, Guid> repository) : base(repository)
        {
            Repository = repository;
        }

        public async Task<EmpresaDto> CreateAsync(CreateGrupoEmpresarialEmpresaKeysDto input)
        {
            await CheckPolicyAsync(CreatePolicyName);

            var empresa = await ReadOnlyRepository.FirstAsync(q => q.Id == input.EmpresaId);

            if (empresa.GrupoEmpresarialId.HasValue)
            {
                throw new BusinessException(SecurityDomainErrorCodes.EmpresaJaEstaRelacionadaAOutroGrupoEmpresarial);
            }

            empresa.GrupoEmpresarialId = input.GrupoEmpresarialId;
            await Repository.UpdateAsync(empresa);

            return ObjectMapper.Map<Empresa, EmpresaDto>(empresa);
        }

        public async Task DeleteAsync(CreateGrupoEmpresarialEmpresaKeysDto id)
        {
            await CheckPolicyAsync(DeletePolicyName);

            var empresa = await ReadOnlyRepository.FirstAsync(q => q.Id == id.EmpresaId && q.GrupoEmpresarialId.HasValue && q.GrupoEmpresarialId == id.GrupoEmpresarialId);
            empresa.GrupoEmpresarialId = null;
            await Repository.UpdateAsync(empresa);
        }

        protected override Task<Empresa> GetEntityByIdAsync(CreateGrupoEmpresarialEmpresaKeysDto id)
        {
            return ReadOnlyRepository
                .FirstAsync(q => q.Id == id.EmpresaId && q.GrupoEmpresarialId.HasValue && q.GrupoEmpresarialId.Value == id.GrupoEmpresarialId);
        }
    }
}
