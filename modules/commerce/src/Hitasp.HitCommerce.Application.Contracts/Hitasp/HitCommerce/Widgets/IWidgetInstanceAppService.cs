using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Widgets.Dtos;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetInstanceAppService : IApplicationService
    {
        Task<ListResultDto<WidgetInstanceDto>> GetPublishedAsync();
        
        Task<PagedResultDto<WidgetInstanceDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<WidgetInstanceDto> CreateAsync(WidgetInstanceCreateDto input);

        Task<WidgetInstanceDto> UpdateAsync(Guid id, WidgetInstanceUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}