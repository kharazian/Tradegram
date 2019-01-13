using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Contents
{
    public class EfCoreContentOptionRepository : EfCoreRepository<IHitCommonDbContext, ContentOption, Guid>,
        IContentOptionRepository
    {
        public EfCoreContentOptionRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<ContentOption>> GetListAsync(string entityTypeId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.EntityTypeId == entityTypeId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ContentOption> FindByNameAsync(string entityTypeId, string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name && x.EntityTypeId == entityTypeId,
                GetCancellationToken(cancellationToken));
        }
    }
}