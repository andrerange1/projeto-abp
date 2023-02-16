using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.Receita2Ingredientes
{
    [RemoteService(false)]
    public class Receita2IngredienteAppService : AbstractKeyCrudAppService<Receita2Ingrediente, Receita2IngredienteDto, Receita2IngredienteKeysDto, GetAllReceita2IngredienteDto, CreateReceita2IngredienteDto, UpdateReceita2IngredienteDto>
    {
        public Receita2IngredienteAppService(IRepository<Receita2Ingrediente> repository) : base(repository)
        {
        }

        protected override Task DeleteByIdAsync(Receita2IngredienteKeysDto input)
            => Repository.DeleteAsync(q => q.IngredienteId == input.IngredienteId && q.ReceitaId == input.ReceitaId);

        protected override Task<Receita2Ingrediente> GetEntityByIdAsync(Receita2IngredienteKeysDto input)
            => Repository.FirstAsync(q => q.IngredienteId == input.IngredienteId && q.ReceitaId == input.ReceitaId);

        protected override async Task<IQueryable<Receita2Ingrediente>> CreateFilteredQueryAsync(GetAllReceita2IngredienteDto input)
        {
            return (await Repository.WithDetailsAsync(q => q.Ingrediente))
                .Where(q => q.ReceitaId == input.ReceitaId)
                .WhereIf(!string.IsNullOrEmpty(input.Search), q => q.Ingrediente.Nome.ToLowerInvariant().Contains(input.Search.ToLowerInvariant()));
        }
    }
}
