using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public class EfCoreAssetBaseRepository<TContext, TAsset> : EfCoreRepository<TContext, TAsset, Guid>,
        IAssetBaseRepository<TAsset> 
        where TAsset : Asset
        where TContext : IEfCoreDbContext
    {
        public EfCoreAssetBaseRepository(IDbContextProvider<TContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<TAsset> FindByUniqueNameAsync(string uniqueFileName, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.UniqueName == uniqueFileName,
                GetCancellationToken(cancellationToken));
        }
        
        public virtual List<TAsset> GetList(Guid spaceId, bool includeDetails = false)
        {
            return includeDetails
                ? WithDetails().Where(x => x.SpaceId == spaceId).ToList()
                : DbSet.ToList();
        }

        public virtual async Task<List<TAsset>> GetListAsync(Guid spaceId, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().Where(x => x.SpaceId == spaceId)
                    .ToListAsync(GetCancellationToken(cancellationToken))
                : await DbSet.ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}