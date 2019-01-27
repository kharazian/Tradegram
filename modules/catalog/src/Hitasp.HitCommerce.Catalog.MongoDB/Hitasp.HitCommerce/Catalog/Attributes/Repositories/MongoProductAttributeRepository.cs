using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class MongoProductAttributeRepository : MongoDbRepository<ICatalogMongoDbContext, ProductAttribute, Guid>,
        IProductAttributeRepository
    {
        public MongoProductAttributeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}