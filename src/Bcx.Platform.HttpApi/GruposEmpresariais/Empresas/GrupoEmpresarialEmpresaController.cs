using Bcx.Platform.Empresas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Bcx.Platform.GruposEmpresariais.Empresas
{
    [Controller]
    // [RemoteService(Name = TenantManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("grupoempresarial")]
    [ControllerName("GrupoEmpresarial")]
    [Route("/api/app/grupo-empresarial/{grupoId:guid}/empresa")]
    public class GrupoEmpresarialEmpresaController : AbpController
    {

        private readonly IGrupoEmpresarialEmpresaAppService _grupoEmpresarialEmpresaAppService;

        public GrupoEmpresarialEmpresaController(IGrupoEmpresarialEmpresaAppService grupoEmpresarialEmpresaAppService)
        {
            _grupoEmpresarialEmpresaAppService = grupoEmpresarialEmpresaAppService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<EmpresaDto>>> GetAllAsync(Guid grupoId, GrupoEmpresarialEmpresaGetAllInput input)
        {
            var filters = new GetAllGrupoEmpresarialEmpresaDto { GrupoEmpresarialId = grupoId };

            ObjectMapper.Map(input, filters);

            return Ok(await _grupoEmpresarialEmpresaAppService.GetListAsync(filters));
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDto>> CreateAsync(Guid grupoId, EntityDto<Guid> input)
        {
            var empresa = await _grupoEmpresarialEmpresaAppService
                .CreateAsync(new CreateGrupoEmpresarialEmpresaKeysDto { EmpresaId = input.Id, GrupoEmpresarialId = grupoId });

            return CreatedAtAction(nameof(GetByIdAsync), new { GroupId = empresa.GrupoEmpresarialId, Id = empresa.Id }, empresa);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<EmpresaDto>> GetByIdAsync(Guid grupoId, Guid id)
        {
            var empresa = await _grupoEmpresarialEmpresaAppService
                .GetAsync(new CreateGrupoEmpresarialEmpresaKeysDto { GrupoEmpresarialId = grupoId, EmpresaId = id });

            return Ok(empresa);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid grupoId, Guid id)
        {
            await _grupoEmpresarialEmpresaAppService
                .DeleteAsync(new CreateGrupoEmpresarialEmpresaKeysDto { EmpresaId = id, GrupoEmpresarialId = grupoId });

            return Ok();
        }

    }
}
