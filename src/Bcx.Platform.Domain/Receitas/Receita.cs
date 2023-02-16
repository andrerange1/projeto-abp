using Bcx.Platform.Receita2Ingredientes;
using Bcx.Platform.ReceitaFotos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Bcx.Platform.Receitas
{
    public class Receita : FullAuditedEntity<int>
    {
        [Required(ErrorMessage = ReceitaConsts.AutorIsRequired)]
        public Guid AutorId { get; set; }
        public IdentityUser Autor { get; set; }

        [Required(ErrorMessage = ReceitaConsts.TituloIsRequired)]
        [MaxLength(ReceitaConsts.TituloMaxLength, ErrorMessage = ReceitaConsts.TituloLessThenMaxLength)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = ReceitaConsts.DescricaoIsRequired)]
        public string Descricao { get; set; }

        public ICollection<Receita2Ingrediente> Ingredientes { get; set; } = new List<Receita2Ingrediente>();

        public ICollection<ReceitaFoto> Fotos { get; set; } = new List<ReceitaFoto>();
    }
}
