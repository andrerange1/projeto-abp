using Bcx.Platform.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Bcx.Platform.Security
{

    public class PlatformAuthorizationOptions
    {
        public static string PlatformAuthorizationSync = "Authorization:Syncronization";

        public PlatformAuthorizationOptions() { }

        /// <summary>
        /// Realiza um mapeamento das chaves do token JWT para um objeto de usuário padronizado
        /// </summary>
        public Func<ClaimsPrincipal, IdentityUserDto> JwtClaimsToIdentityUserMapper { get; } = claims => claims.ToIdentityUser();

        /// <summary>
        /// Quando um usuário for sincronizado, define a Role padrão para usuários.
        /// </summary>
        public string DefaultRole = RoleConsts.VisitorRoleName;

        /// <summary>
        /// Quando um usuário for sincronizado, define a Role padrão para usuários Becomex.
        /// </summary>
        public string DefaultBecomexRole = RoleConsts.DeveloperRole;

        /// <summary>
        /// Default application user email
        /// </summary>
        public string ApplicationUserEmail = "admin@admin.com";
    }
}
