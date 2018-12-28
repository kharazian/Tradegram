using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Widgets
{
    public class EfCoreWidgetInstanceRepository: EfCoreRepository<HitCommerceDbContext, WidgetInstance, Guid>,
        IWidgetInstanceRepository
    {
        public EfCoreWidgetInstanceRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<WidgetInstance>> GetAllByWidgetId(Guid widgetId)
        {
            return await DbSet.Where(x => x.WidgetId == widgetId).ToListAsync();
        }

        public async Task<List<WidgetInstance>> GetAllByWidgetZoneId(int widgetZoneId)
        {
            return await DbSet.Where(x => x.WidgetZoneId == widgetZoneId).ToListAsync();
        }

        public async Task<List<WidgetInstance>> GetPublished()
        {
            return await DbSet.Where(x => x.IsPublished).ToListAsync();
        }

        public async Task<WidgetInstance> GetByName(string name)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}