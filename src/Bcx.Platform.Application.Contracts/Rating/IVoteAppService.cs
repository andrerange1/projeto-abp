using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.Rating
{
    public interface IVoteAppService : ICreateAppService<VoteDto>, IUpdateAppService<SimpleVoteDto, VoteKeysDto>, IDeleteAppService<VoteKeysDto>
    {
    }
}
