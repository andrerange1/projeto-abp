using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.Ingredientes
{
    public interface IIngredienteAppService : ICrudAppService<IngredienteDto, int, GetAllIngredienteDto, CreateUpdateIngredienteDto>
    {
    }
}
