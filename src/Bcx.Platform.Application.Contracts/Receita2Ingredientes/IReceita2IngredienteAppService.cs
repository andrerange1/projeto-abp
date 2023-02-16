using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.Receita2Ingredientes
{
    public interface IReceita2IngredienteAppService : ICrudAppService<Receita2IngredienteDto, Receita2IngredienteKeysDto, GetAllReceita2IngredienteDto, CreateReceita2IngredienteDto, UpdateReceita2IngredienteDto>
    {
    }
}
