using System.Threading.Tasks;

namespace Countries.Data;

public interface ICountriesDbSchemaMigrator
{
    Task MigrateAsync();
}
