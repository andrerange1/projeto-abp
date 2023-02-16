using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Volo.Abp.Identity;

namespace Bcx.Platform.Security
{
    public class SyncUserResultDto
    {
        public IdentityUserDto User { get; set; }
        public ClaimsIdentity Claims { get; set; }
    }
}
