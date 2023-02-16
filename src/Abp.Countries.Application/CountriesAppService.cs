using System;
using System.Collections.Generic;
using System.Text;
using Abp.Countries.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Countries;

/* Inherit your application services from this class.
 */
public abstract class CountriesAppService : ApplicationService
{
    protected CountriesAppService()
    {
        LocalizationResource = typeof(CountriesResource);
    }
}
