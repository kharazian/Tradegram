using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories
{
    public class MongoSpecificationAttributeRepository : MongoDbRepository<ICatalogMongoDbContext, SpecificationAttribute, Guid>,
        ISpecificationAttributeRepository
    {
        public MongoSpecificationAttributeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}