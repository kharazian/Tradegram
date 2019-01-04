using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    public class CatalogMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public CatalogMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = CatalogConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}