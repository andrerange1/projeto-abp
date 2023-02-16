using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.Rating
{
    [RemoteService(false)]
    public class VoteAppService : ApplicationService,
        IVoteAppService
    {
        protected const string CreateVotePolicyName = "";
        protected const string UpdateVotePolicyName = "";
        protected const string DeleteVotePolicyName = "";

        private readonly IRepository<Vote> Repository;

        public VoteAppService(IRepository<Vote> repository)
        {
            Repository = repository;
        }

        public async Task<VoteDto> CreateAsync(VoteDto input)
        {
            await CheckPolicyAsync(CreateVotePolicyName);
            var vote = ObjectMapper.Map<VoteDto, Vote>(input);
            var result = await Repository.InsertAsync(vote, true);
            return ObjectMapper.Map<Vote, VoteDto>(result);
        }

        public async Task DeleteAsync(VoteKeysDto input)
        {
            await CheckPolicyAsync(DeleteVotePolicyName);
            await Repository.DeleteAsync(q => q.UserId == input.UserId && q.ReceitaId == input.ReceitaId, true);
        }

        public async Task<SimpleVoteDto> UpdateAsync(VoteKeysDto keys, SimpleVoteDto input)
        {
            await CheckPolicyAsync(UpdateVotePolicyName);
            var vote = await Repository.FirstAsync(q => q.UserId == keys.UserId && q.ReceitaId == keys.ReceitaId);
            vote.Score = input.Score;
            await Repository.UpdateAsync(vote);
            return ObjectMapper.Map<Vote, SimpleVoteDto>(vote);
        }
    }
}
