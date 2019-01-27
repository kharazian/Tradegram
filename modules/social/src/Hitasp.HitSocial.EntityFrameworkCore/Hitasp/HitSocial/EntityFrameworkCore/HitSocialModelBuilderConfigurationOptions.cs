using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitSocial.EntityFrameworkCore
{
    public class HitSocialModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public HitSocialModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = HitSocialConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitSocialConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}