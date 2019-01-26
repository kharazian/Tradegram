using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class MongoSpecificationAttributeOptionRepository : MongoDbRepository<ICatalogMongoDbContext, SpecificationAttributeOption, Guid>,
        ISpecificationAttributeOptionRepository
    {
        public MongoSpecificationAttributeOptionRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}