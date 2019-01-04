using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [ConnectionStringName("Catalog")]
    public class CatalogDbContext : AbpDbContext<CatalogDbContext>, ICatalogDbContext
    {
        public static string TablePrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = CatalogConsts.DefaultDbSchema;

        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCatalog(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}