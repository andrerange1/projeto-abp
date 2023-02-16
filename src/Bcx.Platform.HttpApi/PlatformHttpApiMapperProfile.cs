using AutoMapper;
using Bcx.Platform.GruposEmpresariais.Empresas;
using Bcx.Platform.Receita2Ingredientes;
using Bcx.Platform.UserTenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcx.Platform
{
    public class SecurityHttpApiMapperProfile : Profile
    {
        public SecurityHttpApiMapperProfile()
        {
            CreateMap<GrupoEmpresarialEmpresaGetAllInput, GetAllGrupoEmpresarialEmpresaDto>().ReverseMap();
            CreateMap<UserTenantsGetAllInput, GetAllUserTenantDto>().ReverseMap();
            CreateMap<Recaita2IngredienteIndexInputDto, GetAllReceita2IngredienteDto>().ReverseMap();
        }
    }
}
