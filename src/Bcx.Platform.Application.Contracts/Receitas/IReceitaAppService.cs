using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.Receitas
{
    public interface IReceitaAppService : ICrudAppService<ReceitaDto, int, GetAllReceitaDto, CreateUpdateReceitaDto>
    {
    }
}
