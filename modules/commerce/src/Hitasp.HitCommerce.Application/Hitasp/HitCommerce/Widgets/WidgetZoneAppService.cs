using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Widgets.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Widgets
{
    public class WidgetZoneAppService : AsyncCrudAppService<WidgetZone, WidgetZoneDto, int,
        WidgetZoneGetListInput, WidgetZoneCreateOrEditDto, WidgetZoneCreateOrEditDto>,
        IWidgetZoneAppService
    {
        private readonly IWidgetZoneRepository _repository;
        public WidgetZoneAppService(IWidgetZoneRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<WidgetZoneDto>> GetListAsync()
        {
            var widgets = await _repository.GetListAsync();
            
            return new ListResultDto<WidgetZoneDto>(ObjectMapper.Map<List<WidgetZone>, List<WidgetZoneDto>>(widgets));
        }
    }
}