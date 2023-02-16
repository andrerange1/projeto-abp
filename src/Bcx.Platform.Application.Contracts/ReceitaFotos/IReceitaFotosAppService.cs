using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.ReceitaFotos
{
    public interface IReceitaFotosAppService :
        IReadOnlyAppService<ReceitaFotoDto, ReceitaFotoKeysDto, GetAllReceitaFotoDto>,
        ICreateAppService<ReceitaFotoDto, CreateUpdateReceitaFotoDto>,
        IDeleteAppService<ReceitaFotoKeysDto>
    {
    }
}
