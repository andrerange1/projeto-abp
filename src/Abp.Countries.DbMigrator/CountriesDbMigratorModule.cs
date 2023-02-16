using Abp.Countries.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Countries.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CountriesEntityFrameworkCoreModule),
    typeof(CountriesApplicationContractsModule)
    )]
public class CountriesDbMigratorModule : AbpModule
{

}
