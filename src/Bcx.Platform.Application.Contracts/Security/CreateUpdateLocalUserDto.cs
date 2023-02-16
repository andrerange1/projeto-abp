using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;

namespace Bcx.Platform.Security
{
    public class CreateUpdateLocalUserDto
    {
        public IdentityUserDto User { get; set; }
    }
}
