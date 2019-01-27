using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitSocial.MongoDB
{
    public static class HitSocialMongoDbContextExtensions
    {
        public static void ConfigureHitSocial(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HitSocialMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
        }
    }
}