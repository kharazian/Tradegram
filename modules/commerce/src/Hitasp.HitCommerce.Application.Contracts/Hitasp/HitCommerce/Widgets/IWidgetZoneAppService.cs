using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Widgets.Dtos;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetZoneAppService : IAsyncCrudAppService<WidgetZoneDto, int,
        WidgetZoneGetListInput, WidgetZoneCreateDto, WidgetZoneUpdateDto>
    {
        Task<ListResultDto<WidgetZoneDto>> GetListAsync();
    }
}