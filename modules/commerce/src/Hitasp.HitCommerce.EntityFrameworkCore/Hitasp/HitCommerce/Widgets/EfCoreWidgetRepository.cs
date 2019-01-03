using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Widgets
{
    public class EfCoreWidgetRepository : EfCoreRepository<HitCommerceDbContext, Widget, Guid>,
        IWidgetRepository
    {
        public EfCoreWidgetRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Widget> FindByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}