using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform
{
    public static class SecurityDomainErrorCodes
    {
        // Empresa
        public const string EmpresaCnpjDeveTer14Digitos = "Cnpj deve possuir 14 dígitos!";
        public const string EmpresaCnpjRequerido = "Cnpj é um campo obrigatório.";
        public const string EmpresaRazaoSocialRequerido = "Razão Social é um campo obrigatório.";

        // GrupoEmpresarial
        public const string GrupoEmpresarialNameRequired = "O campo nome é obrigatório.";
        public const string RaizCnpjNaoDeveUltrapassar8Digitos = "Uma raíz CNPJ não deve ultrapassar 8 dígitos.";

        // GrupoEmpresarial/Empresas
        public const string EmpresaJaEstaRelacionadaAOutroGrupoEmpresarial = "Esta empresa ja está relacionada a outro grupo empresarial. Remova a antiga relação primeiro.";

        // UserTenant
        public const string UserTenantUserRequired = "O campo usuário é obrigatório.";
        public const string UserTenantTenantRequired = "O campo tenant é obrigatório";

        // Security
        public const string UserSyncFail = "Não foi possível sincronizar usuários entre a Plataforma e a Aplicação";
    }
}
