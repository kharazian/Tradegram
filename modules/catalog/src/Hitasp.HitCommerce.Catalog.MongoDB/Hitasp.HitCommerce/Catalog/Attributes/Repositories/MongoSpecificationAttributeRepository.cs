using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class MongoSpecificationAttributeRepository : MongoDbRepository<ICatalogMongoDbContext, SpecificationAttribute, Guid>,
        ISpecificationAttributeRepository
    {
        public MongoSpecificationAttributeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}