using System.Threading.Tasks;

namespace Bcx.Platform.Data
{
    public interface IPlatformDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
