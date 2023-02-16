using IdentityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform.Security
{
    public static class AzureAdClaimTypes
    {
        /// <summary>
        /// Default: <see cref="JwtClaimTypes.PreferredUserName"/>
        /// </summary>
        public static string UserName { get; set; } = JwtClaimTypes.PreferredUserName;

        /// <summary>
        /// Default: oid > http://schemas.microsoft.com/identity/claims/objectidentifier/>
        /// </summary>
        public static string UserId { get; set; } = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        /// <summary>
        /// Default: <see cref="JwtClaimTypes.Role"/>
        /// </summary>
        public static string Role { get; set; } = JwtClaimTypes.Role;

        /// <summary>
        /// Default: <see cref="JwtClaimTypes.PreferredUserName"/>
        /// </summary>
        public static string Email { get; set; } = JwtClaimTypes.PreferredUserName;

        /// <summary>
        /// Version of Token Api
        /// </summary>
        public static string Version { get; set; } = "ver";

        public static string Name { get; set; } = JwtClaimTypes.Name;
    }
}
