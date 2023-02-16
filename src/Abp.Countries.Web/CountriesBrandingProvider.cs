using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abp.Countries.Web;

[Dependency(ReplaceServices = true)]
public class CountriesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Countries";
}
