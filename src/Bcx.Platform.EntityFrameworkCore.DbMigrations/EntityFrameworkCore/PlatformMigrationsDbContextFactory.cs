using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bcx.Platform.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class PlatformMigrationsDbContextFactory : IDesignTimeDbContextFactory<PlatformMigrationsDbContext>
    {
        public PlatformMigrationsDbContext CreateDbContext(string[] args)
        {
            PlatformEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PlatformMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"));

            return new PlatformMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Bcx.Platform.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
