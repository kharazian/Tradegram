using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductTemplateAttributeRepository : MongoDbRepository<ICatalogMongoDbContext, ProductTemplateAttribute>,
        IProductTemplateAttributeRepository
    {
        public MongoProductTemplateAttributeRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}