using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetInstanceRepository : IBasicRepository<WidgetInstance, Guid>
    {
        Task<List<WidgetInstance>> GetAllByWidgetId(Guid widgetId);

        Task<List<WidgetInstance>> GetAllByWidgetZoneId(int widgetZoneId);

        Task<List<WidgetInstance>> GetPublished();
        
        Task<WidgetInstance> GetByName(string name);
    }
}