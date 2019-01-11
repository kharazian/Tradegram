using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.EntityFrameworkCore;
using Hitasp.HitCommon.Media;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Medias
{
    public class EfCoreMediaRepository<TMedia> : EfCoreRepository<IHitCommonDbContext, TMedia, Guid>,
        IMediaRepository<TMedia> where TMedia : AssetBase, IMedia
    {
        public EfCoreMediaRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<TMedia> FindByUniqueName(string uniqueFileName, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.UniqueName == uniqueFileName,
                GetCancellationToken(cancellationToken));
        }
    }
}