using Bcx.Platform.Receitas;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Bcx.Platform.Rating
{
    public class Vote : Entity
    {
        [Required(ErrorMessage = RatingConsts.UserIdIsRequired)]
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required(ErrorMessage = RatingConsts.ReceitaIdIsRequired)]
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }

        [Range(1, 5, ErrorMessage = RatingConsts.VoteRange)]
        public int Score { get; set; }

        public override object[] GetKeys()
            => new object[]
            {
                UserId,
                ReceitaId
            };
    }
}
