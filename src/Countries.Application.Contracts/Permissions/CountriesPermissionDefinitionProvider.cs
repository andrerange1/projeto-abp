using Countries.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Countries.Permissions;

public class CountriesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CountriesPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CountriesPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CountriesResource>(name);
    }
}
