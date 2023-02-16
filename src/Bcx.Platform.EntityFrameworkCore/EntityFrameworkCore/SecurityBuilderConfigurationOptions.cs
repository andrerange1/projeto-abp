using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcx.Platform.EntityFrameworkCore
{
    public class SecurityBuilderConfigurationOptions
    {
        public string DbTablePrefix = SecurityConsts.DbTablePrefix;
        public string DbSchema = SecurityConsts.DbSchema;
    }
}
