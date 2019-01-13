using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Entities
{
    public class MongoEntityTypeRepository : MongoDbRepository<IHitCommonMongoDbContext, EntityType, string>, 
        IEntityTypeRepository
    {
        public MongoEntityTypeRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<EntityType>> GetListAsync(string areaName, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.AreaName == areaName)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<EntityType> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }
    }
}
