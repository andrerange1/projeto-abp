using Countries.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Countries.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CountriesController : AbpControllerBase
{
    protected CountriesController()
    {
        LocalizationResource = typeof(CountriesResource);
    }
}
