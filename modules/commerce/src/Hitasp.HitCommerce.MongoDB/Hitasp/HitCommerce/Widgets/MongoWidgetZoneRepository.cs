using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Widgets
{
    public class MongoWidgetZoneRepository : MongoDbRepository<IHitCommerceMongoDbContext, WidgetZone, int>,
        IWidgetZoneRepository
    {
        public MongoWidgetZoneRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}