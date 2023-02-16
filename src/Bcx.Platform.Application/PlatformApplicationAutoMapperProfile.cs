using AutoMapper;
using Bcx.Platform.Ingredientes;
using Bcx.Platform.Rating;
using Bcx.Platform.Receita2Ingredientes;
using Bcx.Platform.ReceitaFotos;
using Bcx.Platform.Receitas;
using Volo.Abp.Identity;

namespace Bcx.Platform
{
    public class PlatformApplicationAutoMapperProfile : Profile
    {
        public PlatformApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Ingrediente, IngredienteDto>().ReverseMap();
            CreateMap<IngredienteDto, CreateUpdateIngredienteDto>().ReverseMap();
            CreateMap<Ingrediente, CreateUpdateIngredienteDto>().ReverseMap();

            CreateMap<Vote, VoteDto>().ReverseMap();
            CreateMap<Vote, SimpleVoteDto>().ReverseMap();
            CreateMap<VoteDto, SimpleVoteDto>().ReverseMap();

            CreateMap<Receita2Ingrediente, Receita2IngredienteDto>().ReverseMap();
            CreateMap<Receita2Ingrediente, CreateReceita2IngredienteDto>().ReverseMap();
            CreateMap<Receita2Ingrediente, UpdateReceita2IngredienteDto>().ReverseMap();
            CreateMap<Receita2IngredienteDto, Receita2IngredienteKeysDto>().ReverseMap();
            CreateMap<CreateReceita2IngredienteDto, Receita2IngredienteKeysDto>().ReverseMap();

            CreateMap<ReceitaFoto, ReceitaFotoDto>().ReverseMap();
            CreateMap<ReceitaFoto, CreateUpdateReceitaFotoDto>().ReverseMap();
            CreateMap<ReceitaFotoDto, CreateUpdateReceitaFotoDto>().ReverseMap();
            CreateMap<ReceitaFotoKeysDto, CreateUpdateReceitaFotoDto>().ReverseMap();
            CreateMap<ReceitaFotoKeysDto, ReceitaFotoDto>().ReverseMap();

            CreateMap<Receita, ReceitaDto>().ReverseMap();
            CreateMap<Receita, CreateUpdateReceitaDto>().ReverseMap();
            CreateMap<ReceitaDto, CreateUpdateReceitaDto>().ReverseMap();

            CreateMap<IdentityUser, IdentityUserDto>().ReverseMap();
        }
    }
}
