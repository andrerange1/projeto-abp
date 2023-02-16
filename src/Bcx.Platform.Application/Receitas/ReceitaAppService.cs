using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.Receitas
{
    public class ReceitaAppService : CrudAppService<Receita, ReceitaDto, int, GetAllReceitaDto, CreateUpdateReceitaDto>
    {
        public ReceitaAppService(IRepository<Receita, int> repository) : base(repository)
        {
        }


        protected override async Task<IQueryable<Receita>> CreateFilteredQueryAsync(GetAllReceitaDto input)
        {
            // TODO Remover dependência do EF Core na App Layer quando isso for resolvido https://github.com/abpframework/abp/issues/846 
            return (await Repository.WithDetailsAsync(r => r.Autor, r => r.Fotos))
                .Include(r => r.Ingredientes)
                    .ThenInclude(i => i.Ingrediente)
                    
                .WhereIf(!string.IsNullOrEmpty(input.Search), r => r.Titulo.ToLowerInvariant().Contains(input.Search.ToLowerInvariant()))
                .WhereIf(input.ByAuthorId.HasValue, r => r.AutorId == input.ByAuthorId)
                .WhereIf(!string.IsNullOrEmpty(input.ByAuthorName), r => r.Autor.Name.ToLowerInvariant().Contains(input.Search.ToLowerInvariant()))
                .WhereIf(input.WithIngredientes.Any(), r => r.Ingredientes.Any(i => input.WithIngredientes.Any(x => x == i.IngredienteId)));
        }
    }
}
