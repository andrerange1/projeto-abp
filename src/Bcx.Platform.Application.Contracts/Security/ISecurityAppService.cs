using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Bcx.Platform.Security
{
    public interface ISecurityAppService : IApplicationService
    {
        Task<SyncUserResultDto> GetOrCreateLocalUserAsync(CreateUpdateLocalUserDto input);
        Task<bool> TryUpdateUserDataAsync(CreateUpdateLocalUserDto input);
    }
}
