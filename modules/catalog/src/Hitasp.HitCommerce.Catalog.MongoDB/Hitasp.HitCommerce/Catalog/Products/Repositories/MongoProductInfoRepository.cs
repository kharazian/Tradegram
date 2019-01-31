using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class MongoProductInfoRepository : MongoDbRepository<ICatalogMongoDbContext, ProductInfo, Guid>,
        IProductInfoRepository
    {
        public MongoProductInfoRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<ProductInfo> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.Name == name)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}