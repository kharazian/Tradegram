using System;
using System.Linq;
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

        public async Task<Widget> GetByName(string name)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}