using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Widgets.Dtos;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetInstanceAppService : IAsyncCrudAppService<WidgetInstanceDto, Guid,
        WidgetInstanceGetListInput, WidgetInstanceCreateOrEditDto, WidgetInstanceCreateOrEditDto>
    {
        Task<ListResultDto<WidgetInstanceDto>> GetPublishedAsync();
        
        Task<ListResultDto<WidgetInstanceDto>> GetListByWidgetId(Guid widgetId);

        Task<ListResultDto<WidgetInstanceDto>> GetListByWidgetZoneId(int widgetZoneId);
        
        Task<WidgetInstanceDto> GetByNameAsync(string name);
    }
}