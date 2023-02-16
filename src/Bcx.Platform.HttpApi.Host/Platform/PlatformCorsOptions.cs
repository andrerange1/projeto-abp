using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcx.Platform.Platform
{
    /// <summary>
    /// Configurações de CORS
    /// </summary>
    public class PlatformCorsOptions
    {
        /// <summary>
        /// Centralização de configurações de bloqueio de Cross Origin
        /// </summary>
        public static string PlatformCorsSection = "Cors";

        /// <summary>
        /// Nome padrão para a política de CORS.
        /// </summary>
        public static string DefaultCorsPolicyName = "Default";

        /// <summary>
        /// Nome da política de CORS
        /// </summary>
        public string CorsPolicyName { get; set; } = DefaultCorsPolicyName;

        /// <summary>
        /// Lista de domínios autorizados, separados por vírgula e sem a necessicade de inclusão do protocolo ou porta.
        /// </summary>
        public string AllowedHosts { get; set; } = "localhost";

        public string[] GetAllowedDomains()
        {
            return AllowedHosts
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.RemovePostFix("/").Trim())
                .ToArray();
        }
    }
}
