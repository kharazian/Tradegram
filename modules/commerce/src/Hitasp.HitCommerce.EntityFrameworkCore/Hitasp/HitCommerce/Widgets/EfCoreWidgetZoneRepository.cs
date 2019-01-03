using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Widgets
{
    public class EfCoreWidgetZoneRepository : EfCoreRepository<HitCommerceDbContext, WidgetZone, int>,
        IWidgetZoneRepository
    {
        public EfCoreWidgetZoneRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}