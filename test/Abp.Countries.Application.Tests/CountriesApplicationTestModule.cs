using Volo.Abp.Modularity;

namespace Abp.Countries;

[DependsOn(
    typeof(CountriesApplicationModule),
    typeof(CountriesDomainTestModule)
    )]
public class CountriesApplicationTestModule : AbpModule
{

}
