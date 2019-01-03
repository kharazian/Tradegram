using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Widgets.Dtos;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetAppService : IAsyncCrudAppService<WidgetDto, Guid,
        WidgetGetListInput, WidgetCreateOrEditDto, WidgetCreateOrEditDto>
    {
        Task<ListResultDto<WidgetDto>> GetPublishedAsync();
    }
}