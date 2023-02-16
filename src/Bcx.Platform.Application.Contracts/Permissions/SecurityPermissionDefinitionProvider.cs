using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform.Permissions
{
    class SecurityPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var security = context.AddGroup(SecurityPermissions.SecurityGroup);

            security
                .AddPermission(SecurityPermissions.GrupoEmpresarial.Default, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.GrupoEmpresarial.Criar, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.GrupoEmpresarial.Alterar, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.GrupoEmpresarial.Remover, multiTenancySide: MultiTenancySides.Host);

            security
                .AddPermission(SecurityPermissions.Empresas.Default, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.Empresas.Criar, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.Empresas.Alterar, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.Empresas.Remover, multiTenancySide: MultiTenancySides.Host);

            var identityGroup = context.GetGroup(IdentityPermissions.GroupName);

            identityGroup
                .AddPermission(SecurityPermissions.UserTenants.Default, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.UserTenants.Criar, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.UserTenants.Alterar, multiTenancySide: MultiTenancySides.Host)
                    .AddChild(SecurityPermissions.UserTenants.Remover, multiTenancySide: MultiTenancySides.Host);
        }

    }
}
