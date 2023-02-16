using System.Threading.Tasks;

namespace Abp.Countries.Data;

public interface ICountriesDbSchemaMigrator
{
    Task MigrateAsync();
}
