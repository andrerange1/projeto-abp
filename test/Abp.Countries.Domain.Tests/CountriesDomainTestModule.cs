using Abp.Countries.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.Countries;

[DependsOn(
    typeof(CountriesEntityFrameworkCoreTestModule)
    )]
public class CountriesDomainTestModule : AbpModule
{

}
