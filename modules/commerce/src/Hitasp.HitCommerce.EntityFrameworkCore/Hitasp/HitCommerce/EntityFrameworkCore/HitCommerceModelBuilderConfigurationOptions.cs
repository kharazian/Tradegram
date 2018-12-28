using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    public class HitCommerceModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public HitCommerceModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = HitCommerceConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommerceConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}