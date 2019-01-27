using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class MongoProductProductAttributeRepository : MongoDbRepository<ICatalogMongoDbContext, ProductProductAttribute, Guid>,
        IProductProductAttributeRepository
    {
        public MongoProductProductAttributeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}