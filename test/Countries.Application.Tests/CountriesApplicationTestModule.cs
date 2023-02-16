using Volo.Abp.Modularity;

namespace Countries;

[DependsOn(
    typeof(CountriesApplicationModule),
    typeof(CountriesDomainTestModule)
    )]
public class CountriesApplicationTestModule : AbpModule
{

}
