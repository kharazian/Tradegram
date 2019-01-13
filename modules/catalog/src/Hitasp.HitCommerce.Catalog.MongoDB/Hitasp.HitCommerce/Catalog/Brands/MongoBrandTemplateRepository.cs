using System;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class MongoBrandTemplateRepository : MongoDbRepository<IHitCommonMongoDbContext, BrandTemplate, Guid>, IBrandTemplateRepository
    {
        public MongoBrandTemplateRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}