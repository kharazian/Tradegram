using System;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class MongoCategoryTemplateRepository : MongoDbRepository<IHitCommonMongoDbContext, CategoryTemplate, Guid>, ICategoryTemplateRepository
    {
        public MongoCategoryTemplateRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}