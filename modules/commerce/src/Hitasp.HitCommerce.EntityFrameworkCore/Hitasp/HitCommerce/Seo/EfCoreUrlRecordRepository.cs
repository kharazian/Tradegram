using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;
using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Seo
{
    public class EfCoreUrlRecordRepository : EfCoreUrlRecordRepositoryBase<IHitCommerceDbContext, UrlRecord>, IUrlRecordRepository
    {
        public EfCoreUrlRecordRepository(IDbContextProvider<IHitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<UrlRecord> FindByEntityIdAsync(Guid entityId, CancellationToken cancellationToken = default)
        {
            return await this.FirstOrDefaultAsync(u => u.EntityId == entityId, GetCancellationToken(cancellationToken));
        }

        public async Task DeleteListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id, cancellationToken: cancellationToken);
            }
        }

        public virtual async Task<List<UrlRecord>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(u => ids.Contains(u.Id)).ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}