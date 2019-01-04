using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    public class CatalogModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public CatalogModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = CatalogConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = CatalogConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}