using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;
using Hitasp.HitCommon.MongoDB.Seo;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Hitasp.HitCommerce.Seo
{
    public class MongoUrlRecordRepository : MongoUrlRecordRepositoryBase<IHitCommerceMongoDbContext, UrlRecord>, IUrlRecordRepository
    {
        public MongoUrlRecordRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<UrlRecord> FindByEntityIdAsync(Guid entityId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(u => u.EntityId == entityId, GetCancellationToken(cancellationToken));
        }

        public async Task DeleteListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id, cancellationToken: cancellationToken);
            }
        }

        public virtual async Task<List<UrlRecord>> GetListAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(u => ids.Contains(u.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}