using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Bcx.Platform.Rating
{
    [ControllerName("Receita")]
    [Area("Receita")]
    [Route("/api/app/receita/{receitaId:int}/vote")]
    public class ReceitaVoteController : AbpController
    {
        private readonly IVoteAppService _voteAppService;

        public ReceitaVoteController(IVoteAppService voteAppService)
        {
            _voteAppService = voteAppService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(int receitaId, [FromBody] SimpleVoteDto body)
        {
            var input = new VoteDto
            {
                ReceitaId = receitaId,
                UserId = CurrentUser.Id.Value,
                Score = body.Score
            };

            await _voteAppService.CreateAsync(input);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(int receitaId, [FromBody] SimpleVoteDto body)
        {
            await _voteAppService.UpdateAsync(new VoteKeysDto { ReceitaId = receitaId, UserId = CurrentUser.Id.Value }, body);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int receitaId)
        {
            await _voteAppService.DeleteAsync(new VoteKeysDto
            {
                ReceitaId = receitaId,
                UserId = CurrentUser.Id.Value
            });

            return NoContent();
        }
    }
}
