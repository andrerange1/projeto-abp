using Bcx.Platform.Empresas;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.GruposEmpresariais.Empresas
{
    public interface IGrupoEmpresarialEmpresaAppService :
        IReadOnlyAppService<EmpresaDto, CreateGrupoEmpresarialEmpresaKeysDto, GetAllGrupoEmpresarialEmpresaDto>,
        ICreateAppService<EmpresaDto, CreateGrupoEmpresarialEmpresaKeysDto>,
        IDeleteAppService<CreateGrupoEmpresarialEmpresaKeysDto>
    {
    }
}
