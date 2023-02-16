using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.Empresas
{
    public interface IEmpresaAppService : ICrudAppService<EmpresaDto, Guid, GetAllEmpresasDto, EmpresaCreateUpdateDto>
    {
    }
}
