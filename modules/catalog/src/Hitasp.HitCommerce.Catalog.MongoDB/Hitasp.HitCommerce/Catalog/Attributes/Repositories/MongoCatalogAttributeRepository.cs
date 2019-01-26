using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class MongoCatalogAttributeRepository : MongoDbRepository<ICatalogMongoDbContext, CatalogAttribute, Guid>,
        ICatalogAttributeRepository
    {
        public MongoCatalogAttributeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}