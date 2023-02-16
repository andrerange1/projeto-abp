using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace Bcx.Platform.Ingredientes
{
    public class IngredienteAppService :
        CrudAppService<Ingrediente, IngredienteDto, int, GetAllIngredienteDto, CreateUpdateIngredienteDto>,
        IIngredienteAppService
    {
        private readonly IIngredientePrecisaSerUnicoRule _createUpdateRule;

        public IngredienteAppService(IRepository<Ingrediente, int> repository,
                                     IIngredientePrecisaSerUnicoRule createUpdateRule) : base(repository)
        {
            _createUpdateRule = createUpdateRule;
        }

        public override async Task<IngredienteDto> CreateAsync(CreateUpdateIngredienteDto input)
        {
            await CheckCreatePolicyAsync();

            var ingrediente = MapToEntity(input);

            _createUpdateRule.IsSatisfiedBy(ingrediente);

            await Repository.InsertAsync(ingrediente, true);

            return MapToGetOutputDto(ingrediente);
        }

        public override async Task<IngredienteDto> UpdateAsync(int id, CreateUpdateIngredienteDto input)
        {
            await CheckUpdatePolicyAsync();

            var ingrediente = await Repository.GetAsync(id);
            ObjectMapper.Map(input, ingrediente);
            _createUpdateRule.IsSatisfiedBy(ingrediente);
            await Repository.UpdateAsync(ingrediente, true);

            return MapToGetListOutputDto(ingrediente);
        }

        protected override Task<IQueryable<Ingrediente>> CreateFilteredQueryAsync(GetAllIngredienteDto input)
        {
            return Task.FromResult(Repository
                .WhereIf(!string.IsNullOrEmpty(input.Search), q => q.Nome.ToLowerInvariant().Contains(input.Search.ToLowerInvariant())));
        }

    }
}
