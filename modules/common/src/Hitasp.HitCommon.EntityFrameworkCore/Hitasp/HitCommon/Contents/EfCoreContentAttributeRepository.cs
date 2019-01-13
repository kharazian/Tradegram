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
    public class EfCoreContentAttributeRepository : EfCoreRepository<IHitCommonDbContext, ContentAttribute, Guid>,
        IContentAttributeRepository
    {
        public EfCoreContentAttributeRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<ContentAttribute>> GetListAsync(Guid attributeGroupId,
            CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.ContentAttributeGroupId == attributeGroupId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ContentAttribute> FindByNameAsync(Guid attributeGroupId, string name,
            CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name && x.ContentAttributeGroupId == attributeGroupId,
                GetCancellationToken(cancellationToken));
        }
    }
}