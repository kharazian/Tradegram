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
    public class MongoProductCodeRepository : MongoDbRepository<ICatalogMongoDbContext, ProductCode, Guid>,
        IProductCodeRepository
    {
        public MongoProductCodeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<bool> IsCodeExistsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().AnyAsync(x => x.Code == code, GetCancellationToken(cancellationToken));
        }
    }
}