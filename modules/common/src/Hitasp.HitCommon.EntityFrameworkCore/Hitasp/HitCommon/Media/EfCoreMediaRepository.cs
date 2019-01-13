using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Media
{
    public class EfCoreMediaRepository<TMedia> : EfCoreAssetBaseRepository<TMedia>,
        IMediaRepository<TMedia> where TMedia : AssetBase, IMedia
    {
        public EfCoreMediaRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }
    }
}