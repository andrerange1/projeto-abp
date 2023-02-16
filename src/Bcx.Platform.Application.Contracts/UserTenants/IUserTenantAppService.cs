using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Bcx.Platform.UserTenants
{
    public interface IUserTenantAppService : ICrudAppService<UserTenantDto, UserTenantKeys, GetAllUserTenantDto, CreateUpdateUserTenantDto>
    {
    }
}
