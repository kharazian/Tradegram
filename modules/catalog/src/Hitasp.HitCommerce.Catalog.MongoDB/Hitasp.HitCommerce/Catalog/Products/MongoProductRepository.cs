using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductRepository : MongoContentBaseRepository<Product, IHitCommonMongoDbContext>, IProductRepository
    {
        public MongoProductRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Product>> GetListAsync(IEnumerable<Guid> ids)
        {
            return await GetMongoQueryable().Where(t => ids.Contains(t.Id)).ToListAsync();
        }
    }
}