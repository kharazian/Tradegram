using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    public class HitCommonMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public HitCommonMongoModelBuilderConfigurationOptions([NotNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}
