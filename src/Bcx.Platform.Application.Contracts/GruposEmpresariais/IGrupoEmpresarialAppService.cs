using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.GruposEmpresariais
{
    public interface IGrupoEmpresarialAppService : ICrudAppService<GrupoEmpresarialDto, Guid, GetAllGrupoEmpresarialDto, GrupoEmpresarialCreateUpdateDto>
    {
    }
}
