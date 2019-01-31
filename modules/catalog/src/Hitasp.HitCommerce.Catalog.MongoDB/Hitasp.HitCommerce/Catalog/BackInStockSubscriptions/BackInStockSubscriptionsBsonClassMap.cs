using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions
{
    public static class BackInStockSubscriptionsBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<BackInStockSubscription>(map => { map.AutoMap(); });
            });
        }
    }
}