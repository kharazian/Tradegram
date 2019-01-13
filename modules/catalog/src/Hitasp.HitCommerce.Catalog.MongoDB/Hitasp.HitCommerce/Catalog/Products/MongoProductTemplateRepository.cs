using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductTemplateRepository : MongoDbRepository<ICatalogMongoDbContext, ProductTemplate, Guid>, IProductTemplateRepository
    {
        public MongoProductTemplateRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}