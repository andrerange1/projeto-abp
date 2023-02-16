using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform.Permissions
{
    public static class SecurityPermissions
    {
        public const string SecurityGroup = "Security";

        public static class GrupoEmpresarial
        {
            public const string Default = SecurityGroup + ".GrupoEmpresarial";
            public const string Criar = Default + ".Criar";
            public const string Alterar = Default + ".Alterar";
            public const string Remover = Default + ".Remover";
        }

        public static class Empresas
        {
            public const string Default = SecurityGroup + ".Empresas";
            public const string Criar = Default + ".Criar";
            public const string Alterar = Default + ".Alterar";
            public const string Remover = Default + ".Remover";
        }

        public static class UserTenants
        {
            public const string Default = SecurityGroup + ".UserTenants";
            public const string Criar = Default + ".Criar";
            public const string Alterar = Default + ".Alterar";
            public const string Remover = Default + ".Remover";
        }
    }
}
