using AutoMapper;
using Bcx.Platform.Empresas;
using Bcx.Platform.GruposEmpresariais;
using Bcx.Platform.UserTenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Bcx.Platform
{
    public class SecurityApplicationAutoMapperProfile : Profile
    {
        public SecurityApplicationAutoMapperProfile()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ForMember(p => p.GrupoEmpresarialNome, options =>
                {
                    options.MapFrom(x => x.GrupoEmpresarial.Nome);
                })
                .ReverseMap();
            CreateMap<Empresa, EmpresaCreateUpdateDto>().ReverseMap();
            CreateMap<EmpresaDto, EmpresaCreateUpdateDto>().ReverseMap();

            CreateMap<GrupoEmpresarial, GrupoEmpresarialDto>().ReverseMap();
            CreateMap<GrupoEmpresarial, GrupoEmpresarialCreateUpdateDto>().ReverseMap();
            CreateMap<GrupoEmpresarialDto, GrupoEmpresarialCreateUpdateDto>().ReverseMap();

            CreateMap<UserTenant, UserTenantDto>()
                .ForMember(p => p.TenantName, options =>
                {
                    options.MapFrom(x => x.Tenant.Name);
                })
                .ReverseMap();
            CreateMap<UserTenant, CreateUpdateUserTenantDto>().ReverseMap();
            CreateMap<UserTenantDto, CreateUpdateUserTenantDto>().ReverseMap();
            CreateMap<UserTenantDto, UserTenantKeys>().ReverseMap();
            CreateMap<UserTenant, UserTenantKeys>().ReverseMap();
            CreateMap<CreateUpdateUserTenantDto, UserTenantKeys>().ReverseMap();

            CreateMap<IdentityUserDto, IdentityUser>().ReverseMap();
        }
    }
}
