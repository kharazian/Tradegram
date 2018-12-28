using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Widgets
{
    public class MongoWidgetRepository : MongoDbRepository<IHitCommerceMongoDbContext, Widget, Guid>,
        IWidgetRepository
    {
        public MongoWidgetRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<Widget> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}