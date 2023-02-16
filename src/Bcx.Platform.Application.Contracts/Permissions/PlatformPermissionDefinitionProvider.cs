using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bcx.Platform.Permissions
{
    public class PlatformPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            // var myGroup = context.AddGroup(PlatformPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(PlatformPermissions.MyPermission1, L("Permission:MyPermission1"));

            var state = context.AddGroup(PlatformPermissions.StateGroup);
            state.AddPermission(PlatformPermissions.StateGetAllPermission);
        }

    }
}
