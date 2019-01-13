using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Media
{
    public class EfCorePictureRepository : EfCoreMediaRepository<Picture>
    {
        public EfCorePictureRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}