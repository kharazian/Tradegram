using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Widgets.Dtos;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetAppService : IApplicationService
    {
        Task<ListResultDto<WidgetDto>> GetPublishedAsync();
        
        Task<PagedResultDto<WidgetDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<WidgetDto> CreateAsync(WidgetCreateDto input);

        Task<WidgetDto> UpdateAsync(Guid id, WidgetUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}