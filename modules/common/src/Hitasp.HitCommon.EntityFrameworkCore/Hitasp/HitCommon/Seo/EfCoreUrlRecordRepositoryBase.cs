using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Seo
{
    public abstract class EfCoreUrlRecordRepositoryBase<TDbContext, TUrlRecord> : EfCoreRepository<TDbContext, TUrlRecord, Guid>, IUrlRecordRepositoryBase<TUrlRecord>
        where TDbContext : IEfCoreDbContext
        where TUrlRecord : class, IUrlRecord
    {
        protected EfCoreUrlRecordRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<TUrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await this.FirstOrDefaultAsync(u => u.Slug == slug, GetCancellationToken(cancellationToken));
        }
    }
}