using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class MongoPredefinedAttributeValueRepository : MongoDbRepository<ICatalogMongoDbContext, PredefinedAttributeValue, Guid>,
        IPredefinedAttributeValueRepository
    {
        public MongoPredefinedAttributeValueRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}