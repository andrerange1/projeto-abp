using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Bcx.Platform.Receita2Ingredientes
{
    [ControllerName("Receita")]
    [Area("Receita")]
    [Route("/api/app/receita/{receitaId:int}/ingrediente")]
    public class Receita2IngredienteController : AbpController
    {
        private readonly IReceita2IngredienteAppService _receita2IngredienteAppService;

        public Receita2IngredienteController(IReceita2IngredienteAppService receita2IngredienteAppService)
        {
            _receita2IngredienteAppService = receita2IngredienteAppService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<Receita2IngredienteDto>>> IndexAsync(int receitaId, [FromQuery] Recaita2IngredienteIndexInputDto query)
        {
            var input = new GetAllReceita2IngredienteDto { ReceitaId = receitaId };
            ObjectMapper.Map(query, input);
            var result = await _receita2IngredienteAppService.GetListAsync(input);

            return Ok(result);
        }

        [HttpGet("{ingredienteId:int}")]
        public async Task<ActionResult<Receita2IngredienteDto>> GetByIdAsync(int receitaId, int ingredienteId)
        {
            var result = await _receita2IngredienteAppService.GetAsync(new Receita2IngredienteKeysDto
            {
                ReceitaId = receitaId,
                IngredienteId = ingredienteId
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Receita2IngredienteDto>> CreateAsync(int receitaId, [FromBody] UpdateReceita2IngredienteDto body)
        {
            var input = new CreateReceita2IngredienteDto { ReceitaId = receitaId };
            ObjectMapper.Map(body, input);
            var result = await _receita2IngredienteAppService.CreateAsync(input);

            return CreatedAtAction(nameof(GetByIdAsync), new { ReceitaId = receitaId, result.IngredienteId }, result);
        }

        [HttpPut("{ingredienteId:int}")]
        public async Task<ActionResult<Receita2IngredienteDto>> UpdateAsync(int receitaId, int ingredienteId, [FromBody] UpdateReceita2IngredienteDto body)
        {
            var result = await _receita2IngredienteAppService.UpdateAsync(new Receita2IngredienteKeysDto
            {
                ReceitaId = receitaId,
                IngredienteId = ingredienteId
            }, body);

            return Ok(result);
        }

        [HttpDelete("{ingredienteId:int}")]
        public async Task<ActionResult> DeleteAsync(int receitaId, int ingredienteId)
        {
            await _receita2IngredienteAppService.DeleteAsync(new Receita2IngredienteKeysDto
            {
                ReceitaId = receitaId,
                IngredienteId = ingredienteId
            });

            return NoContent();
        }
    }
}
