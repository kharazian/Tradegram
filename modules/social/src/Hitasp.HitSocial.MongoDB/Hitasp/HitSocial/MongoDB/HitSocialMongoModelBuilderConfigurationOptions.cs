using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Hitasp.HitSocial.MongoDB
{
    public class HitSocialMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public HitSocialMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = HitSocialConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}