using Bcx.Platform.Receita2Ingredientes;
using Bcx.Platform.ReceitaFotos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Bcx.Platform.Receitas
{
    public class ReceitaDto : EntityDto<int>
    {
        public Guid AutorId { get; set; }
        public IdentityUserDto Autor { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public ICollection<Receita2IngredienteDto> Ingredientes { get; set; } = new List<Receita2IngredienteDto>();

        public ICollection<ReceitaFotoDto> Fotos { get; set; } = new List<ReceitaFotoDto>();
    }
}
