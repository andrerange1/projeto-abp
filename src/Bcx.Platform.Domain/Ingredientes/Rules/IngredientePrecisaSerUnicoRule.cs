using Bcx.Platform.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Bcx.Platform.Ingredientes
{
    public class IngredientePrecisaSerUnicoRule : IIngredientePrecisaSerUnicoRule, IDomainService, ITransientDependency
    {
        private readonly IRepository<Ingrediente, int> _ingredientes;

        public IngredientePrecisaSerUnicoRule(IRepository<Ingrediente, int> ingredientes)
        {
            _ingredientes = ingredientes;
        }

        public bool IsSatisfiedBy(Ingrediente item)
        {
            var exists = _ingredientes
                .Where(q => q.Nome.ToLowerInvariant().Equals(item.Nome.Trim().ToLowerInvariant()))
                .Any();

            if (exists == true)
            {
                throw new BusinessException("Esse ingrediente já existe mano...");
            }

            return !exists;
        }
    }
}
