using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Bcx.Platform.Security
{
    public class UserSyncronizationException : BusinessException
    {

        public UserSyncronizationException(Exception inner = null) : base(message: SecurityDomainErrorCodes.UserSyncFail, innerException: inner)
        {

        }
    }
}
