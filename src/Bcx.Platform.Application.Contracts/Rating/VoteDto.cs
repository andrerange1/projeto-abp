using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bcx.Platform.Rating
{
    public class VoteDto : EntityDto
    {
        public Guid UserId { get; set; }
        public int ReceitaId { get; set; }
        public int Score { get; set; }
    }
}
