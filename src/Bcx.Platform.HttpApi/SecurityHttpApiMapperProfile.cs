using AutoMapper;
using Bcx.Platform.ReceitaFotos;

namespace Bcx.Platform
{
    public class PlatformHttpApiMapperProfile : Profile
    {
        public PlatformHttpApiMapperProfile()
        {
            CreateMap<ReceitaFotoCreateInputDto, CreateUpdateReceitaFotoDto>().ReverseMap();
            CreateMap<ReceitaFotoIndexInputDto, GetAllReceitaFotoDto>().ReverseMap();
        }
    }
}
