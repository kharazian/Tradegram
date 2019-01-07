using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    public class HitLocationMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public HitLocationMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = HitLocationConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}