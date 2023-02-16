using Countries.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Countries;

[DependsOn(
    typeof(CountriesEntityFrameworkCoreTestModule)
    )]
public class CountriesDomainTestModule : AbpModule
{

}
