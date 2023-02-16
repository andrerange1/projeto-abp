using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Bcx.Platform.ReceitaFotos
{

    [ControllerName("Receita")]
    [Area("Receita")]
    [Route("/api/app/receita/{receitaId:int}/foto")]
    public class ReceitaFotosController : AbpController
    {
        private readonly IReceitaFotosAppService _receitaFotosAppService;

        public ReceitaFotosController(IReceitaFotosAppService receitaFotosAppService)
        {
            _receitaFotosAppService = receitaFotosAppService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<ReceitaFotoDto>>> Index(int receitaId, [FromQuery] ReceitaFotoIndexInputDto input)
        {
            var query = new GetAllReceitaFotoDto { ReceitaId = receitaId };
            var result = await _receitaFotosAppService.GetListAsync(ObjectMapper.Map(input, query));

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReceitaFotoDto>> GetById(int receitaId, int id)
        {
            var result = await _receitaFotosAppService.GetAsync(new ReceitaFotoKeysDto { ReceitaId = receitaId, Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ReceitaFotoDto>> Create(int receitaId, ReceitaFotoCreateInputDto body)
        {
            var input = new CreateUpdateReceitaFotoDto { ReceitaId = receitaId };
            ObjectMapper.Map(body, input);
            var result = await _receitaFotosAppService.CreateAsync(input);

            return CreatedAtAction(nameof(GetById), new { ReceitaId = receitaId, result.Id }, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int receitaId, int id)
        {
            await _receitaFotosAppService.DeleteAsync(new ReceitaFotoKeysDto { ReceitaId = receitaId, Id = id });
            return NoContent();
        }
    }
}
