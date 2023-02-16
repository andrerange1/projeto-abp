using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abp.Countries.Data;

/* This is used if database provider does't define
 * ICountriesDbSchemaMigrator implementation.
 */
public class NullCountriesDbSchemaMigrator : ICountriesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
