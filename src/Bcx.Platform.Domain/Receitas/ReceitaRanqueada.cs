using Bcx.Platform.Receita2Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Bcx.Platform.Receitas
{
    public class ReceitaRanqueada : Entity
    {
        public int Id { get; set; }
        public Guid AutorId { get; set; }
        public string AutorNome { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Thumb { get; set; }

        public double Ranking { get; set; }

        public ICollection<Receita2Ingrediente> Ingredientes { get; set; } = new List<Receita2Ingrediente>();

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
