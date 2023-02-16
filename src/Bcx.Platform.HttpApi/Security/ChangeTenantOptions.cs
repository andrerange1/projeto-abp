using Volo.Abp.MultiTenancy;

namespace Bcx.Platform.Security
{
    public class ChangeTenantOptions
    {
        public static string ChangeTenantSection = "ChangeTenant";

        public string TenantHeaderKey = TenantResolverConsts.DefaultTenantKey;
    }
}
