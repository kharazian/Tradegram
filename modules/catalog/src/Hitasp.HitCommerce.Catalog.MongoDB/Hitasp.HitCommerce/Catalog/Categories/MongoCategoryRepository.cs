using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class MongoCategoryRepository : MongoContentBaseRepository<Category, IHitCommonMongoDbContext>, ICategoryRepository
    {
        public MongoCategoryRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<Category>> GetListByParentIdAsync(Guid parentId)
        {
            return await GetMongoQueryable().Where(x => x.ParentCategoryId == parentId)
                .OrderByDescending(x => x.Name).ToListAsync();
        }
    }
}