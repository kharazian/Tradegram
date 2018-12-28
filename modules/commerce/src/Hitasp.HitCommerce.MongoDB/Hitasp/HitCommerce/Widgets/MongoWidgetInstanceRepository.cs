using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Widgets
{
    public class MongoWidgetInstanceRepository: MongoDbRepository<IHitCommerceMongoDbContext, WidgetInstance, Guid>,
        IWidgetInstanceRepository
    {
        public MongoWidgetInstanceRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<WidgetInstance>> GetAllByWidgetId(Guid widgetId)
        {
            return await GetMongoQueryable().Where(x => x.WidgetId == widgetId).ToListAsync();
        }

        public async Task<List<WidgetInstance>> GetAllByWidgetZoneId(int widgetZoneId)
        {
            return await GetMongoQueryable().Where(x => x.WidgetZoneId == widgetZoneId).ToListAsync();
        }

        public async Task<List<WidgetInstance>> GetPublished()
        {
            return await GetMongoQueryable().Where(x => x.IsPublished).ToListAsync();
        }

        public async Task<WidgetInstance> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}