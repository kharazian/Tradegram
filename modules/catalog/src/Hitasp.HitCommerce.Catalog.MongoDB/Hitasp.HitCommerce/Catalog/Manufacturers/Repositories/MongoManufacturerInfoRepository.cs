using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class MongoManufacturerInfoRepository : MongoDbRepository<ICatalogMongoDbContext, ManufacturerInfo, Guid>,
        IManufacturerInfoRepository
    {
        public MongoManufacturerInfoRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<ManufacturerInfo> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<ManufacturerInfo> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}