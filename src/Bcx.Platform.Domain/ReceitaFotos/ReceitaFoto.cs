using Bcx.Platform.Receitas;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Bcx.Platform.ReceitaFotos
{
    public class ReceitaFoto : Entity<int>
    {
        [Required(ErrorMessage = ReceitaFotoConsts.ReceitaIsRequired)]
        public int ReceitaId { get; set; }
        public bool Default { get; set; } = false;
        [Required(ErrorMessage = ReceitaFotoConsts.UriIsRequired)]
        [MaxLength(ReceitaFotoConsts.UriMaxLength, ErrorMessage = ReceitaFotoConsts.UriLessThenMaxLength)]
        public string Uri { get; set; }
    }
}
