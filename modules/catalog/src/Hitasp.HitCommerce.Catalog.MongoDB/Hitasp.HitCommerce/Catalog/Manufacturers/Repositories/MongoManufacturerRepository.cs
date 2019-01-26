using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class MongoManufacturerRepository : MongoDbRepository<ICatalogMongoDbContext, Manufacturer, Guid>,
        IManufacturerRepository
    {
        public MongoManufacturerRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Manufacturer>> GetListAsync(Guid spaceId, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.SpaceId == spaceId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Manufacturer> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.ManufacturerInfo.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<Manufacturer> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.ManufacturerInfo.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}