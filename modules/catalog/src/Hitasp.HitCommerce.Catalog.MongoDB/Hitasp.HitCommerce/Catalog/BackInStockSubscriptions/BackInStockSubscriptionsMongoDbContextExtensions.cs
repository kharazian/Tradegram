using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions
{
    public static class BackInStockSubscriptionsMongoDbContextExtensions
    {
        public static void ConfigureBackInStockSubscriptions(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);


            builder.Entity<BackInStockSubscription>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "BackInStockSubscriptions";
            });
        }
    }
}