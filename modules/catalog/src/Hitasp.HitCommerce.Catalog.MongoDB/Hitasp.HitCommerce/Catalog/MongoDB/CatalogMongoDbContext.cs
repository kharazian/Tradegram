using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public class CatalogMongoDbContext : AbpMongoDbContext, ICatalogMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCatalog(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}