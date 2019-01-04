using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Seo
{
    public class MongoSeoRepository : MongoDbRepository<IHitCommonMongoDbContext, UrlRecord, Guid>,
        IUrlRecordRepository
    {
        protected MongoSeoRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public async Task<UrlRecord> FindByEntityNameAsync(string entityName, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(u => u.EntityName == entityName, GetCancellationToken(cancellationToken));
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

        public async Task<UrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(u => u.Slug == slug, GetCancellationToken(cancellationToken));
        }
    }
}