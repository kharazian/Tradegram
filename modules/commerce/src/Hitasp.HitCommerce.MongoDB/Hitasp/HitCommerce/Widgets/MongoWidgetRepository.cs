using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;
using MongoDB.Driver;

namespace Hitasp.HitCommerce.Widgets
{
    public class MongoWidgetRepository : MongoDbRepository<IHitCommerceMongoDbContext, Widget, Guid>,
        IWidgetRepository
    {
        public MongoWidgetRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<Widget> FindByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Widget>> GetPublished()
        {
            return await GetMongoQueryable().Where(x => x.IsPublished).ToListAsync();
        }
    }
}