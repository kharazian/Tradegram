using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class MongoProductManufacturerRepository : MongoDbRepository<ICatalogMongoDbContext, ProductManufacturer>,
        IProductManufacturerRepository
    {
        public MongoProductManufacturerRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<List<ProductManufacturer>> GetListByManufacturerIdAsync(Guid manufacturerId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ManufacturerId == manufacturerId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProductManufacturer>> GetListByProductIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ProductId == productId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ProductManufacturer> FindAsync(Guid productId, Guid manufacturerId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}