using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class MongoManufacturerPublishingInfoRepository : MongoDbRepository<ICatalogMongoDbContext, ManufacturerPublishingInfo, Guid>,
        IManufacturerPublishingInfoRepository
    {
        public MongoManufacturerPublishingInfoRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}