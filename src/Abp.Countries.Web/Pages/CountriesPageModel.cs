using Abp.Countries.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Countries.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CountriesPageModel : AbpPageModel
{
    protected CountriesPageModel()
    {
        LocalizationResourceType = typeof(CountriesResource);
    }
}
