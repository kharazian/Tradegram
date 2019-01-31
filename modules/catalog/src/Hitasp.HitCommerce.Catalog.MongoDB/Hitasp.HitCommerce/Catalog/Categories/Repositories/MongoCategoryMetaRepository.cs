using System;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public class MongoCategoryMetaRepository : MongoDbRepository<ICatalogMongoDbContext, CategoryMetaInfo, Guid>,
        ICategoryMetaInfoRepository
    {
        public MongoCategoryMetaRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}