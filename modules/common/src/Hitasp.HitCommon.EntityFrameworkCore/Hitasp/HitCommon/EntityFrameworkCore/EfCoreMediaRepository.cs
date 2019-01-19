using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.Media;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public class EfCoreMediaRepository<TContext, TMedia> : EfCoreAssetBaseRepository<TContext, TMedia>,
        IMediaRepository<TMedia>
        where TMedia : Asset, IMedia
        where TContext : IEfCoreDbContext
    {
        public EfCoreMediaRepository(IDbContextProvider<TContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }
    }
}