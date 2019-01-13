using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductRepository : MongoContentBaseRepository<Product, IHitCommonMongoDbContext>, IProductRepository
    {
        public MongoProductRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}