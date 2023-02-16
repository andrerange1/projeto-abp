using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.ReceitaFotos
{
    [RemoteService(false)]
    public class ReceitaFotoAppService :
        AbstractKeyReadOnlyAppService<ReceitaFoto, ReceitaFotoDto, ReceitaFotoKeysDto, GetAllReceitaFotoDto>,
        IReceitaFotosAppService
    {
        private const string CreatePolicyName = "";
        private const string DeletePolicyName = "";

        private readonly IRepository<ReceitaFoto, int> Repository;

        public ReceitaFotoAppService(IRepository<ReceitaFoto, int> repository) : base(repository)
        {
        }

        public async Task<ReceitaFotoDto> CreateAsync(CreateUpdateReceitaFotoDto input)
        {
            await CheckPolicyAsync(CreatePolicyName);

            var receitaFoto = ObjectMapper.Map<CreateUpdateReceitaFotoDto, ReceitaFoto>(input);
            await Repository.InsertAsync(receitaFoto, true);

            return ObjectMapper.Map<ReceitaFoto, ReceitaFotoDto>(receitaFoto);
        }

        public async Task DeleteAsync(ReceitaFotoKeysDto input)
        {
            await CheckPolicyAsync(DeletePolicyName);
            await Repository.DeleteAsync(q => q.Id == input.Id && q.ReceitaId == input.ReceitaId);
        }

        protected override Task<IQueryable<ReceitaFoto>> CreateFilteredQueryAsync(GetAllReceitaFotoDto input)
        {
            return Task.FromResult(Repository
                .WhereIf(input.IsDefault.HasValue, q => q.Default == input.IsDefault)
                .Where(q => q.ReceitaId == input.ReceitaId));
    }

        protected override Task<ReceitaFoto> GetEntityByIdAsync(ReceitaFotoKeysDto input)
            => Repository.FirstAsync(q => q.Id == input.Id && q.ReceitaId == input.ReceitaId);
    }
}
