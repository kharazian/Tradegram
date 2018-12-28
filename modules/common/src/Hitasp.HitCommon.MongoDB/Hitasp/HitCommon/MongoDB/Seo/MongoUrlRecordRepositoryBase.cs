using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Seo;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB.Seo
{
    public abstract class MongoUrlRecordRepositoryBase<TDbContext, TUrlRecord> 
        : MongoDbRepository<TDbContext, TUrlRecord, Guid>, IUrlRecordRepositoryBase<TUrlRecord>
        where TDbContext : IAbpMongoDbContext
        where TUrlRecord : class, IUrlRecord
    {
        protected MongoUrlRecordRepositoryBase(IMongoDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<TUrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(u => u.Slug == slug, GetCancellationToken(cancellationToken));
        }
    }
}