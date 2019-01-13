using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Assets
{
    public class EfCoreAssetBaseRepository<TAsset> : EfCoreRepository<IHitCommonDbContext, TAsset, Guid>,
        IAssetBaseRepository<TAsset> where TAsset : AssetBase
    {
        public EfCoreAssetBaseRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<TAsset> FindByUniqueNameAsync(string uniqueFileName, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.UniqueName == uniqueFileName,
                GetCancellationToken(cancellationToken));
        }
    }
}