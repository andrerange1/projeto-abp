using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Bcx.Platform.Empresas;
using Bcx.Platform.GruposEmpresariais;
using Bcx.Platform.UserTenants;
using Bcx.Platform.Users;
using Volo.Abp.Identity;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Bcx.Platform.Ingredientes;
using Bcx.Platform.Rating;
using Bcx.Platform.ReceitaFotos;
using Bcx.Platform.Receita2Ingredientes;
using Bcx.Platform.Receitas;

namespace Bcx.Platform.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See PlatformMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class PlatformDbContext : AbpDbContext<PlatformDbContext>
    {
        // public DbSet<AppUser> Users { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Receita2Ingrediente> Receita2Ingredientes { get; set; }
        public DbSet<ReceitaFoto> ReceitaFotos { get; set; }
        public DbSet<Receita> Receitas { get; set; }

        // Security Entities
        public DbSet<GrupoEmpresarial> GruposEmpresariais { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<UserTenant> UserTenants { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside PlatformDbContextModelCreatingExtensions.ConfigurePlatform
         */

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */
            //builder.Entity<AppUser>(b =>
            //{
            //    b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users", AbpIdentityDbProperties.DbSchema); //Sharing the same table "AbpUsers" with the IdentityUser
                
            //    b.ConfigureByConvention();
            //    b.ConfigureAbpUser();

            //    /** 
            //     * NÃO RELA A MÃO AQUI MERMÃO!!! Faça um relacionamento OneToOne com o IdentityUser
            //     * e sincroniza ambos com os eventos de domínio!
            //     * Esse user aqui é todo cagado!
            //     */
            //});

            /* Configure your own tables/entities inside the ConfigurePlatform method */
            builder.ConfigureSecurity();
            builder.ConfigureIdentity();
            builder.ConfigureTenantManagement();
            builder.ConfigurePlatform();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
#if DEBUG
            options.EnableDetailedErrors(true);
            options.EnableSensitiveDataLogging(true);
#endif
            base.OnConfiguring(options);
        }
    }
}
