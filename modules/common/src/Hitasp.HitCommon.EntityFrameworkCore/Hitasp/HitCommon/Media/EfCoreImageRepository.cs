using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Media
{
    public class EfCoreImageRepository : EfCoreMediaRepository<Image>
    {
        public EfCoreImageRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}