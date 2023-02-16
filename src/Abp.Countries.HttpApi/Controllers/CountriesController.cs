using Abp.Countries.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Countries.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CountriesController : AbpControllerBase
{
    protected CountriesController()
    {
        LocalizationResource = typeof(CountriesResource);
    }
}
