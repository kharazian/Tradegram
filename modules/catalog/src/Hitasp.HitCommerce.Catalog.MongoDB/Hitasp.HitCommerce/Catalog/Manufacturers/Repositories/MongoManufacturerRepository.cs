using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.MongoDB;
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
    }
}