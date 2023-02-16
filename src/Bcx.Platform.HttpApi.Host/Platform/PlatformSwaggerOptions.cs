using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcx.Platform.Security
{
    public class PlatformSwaggerOptions
    {
        public static string PlatformSwaggerSection = "PlatformSwagger";

        public string ApiName { get; set; }
        public string Scope { get; set; }
        public string TokenUrl { get; set; }
        public string AuthorizationUrl { get; set; }
    }
}
