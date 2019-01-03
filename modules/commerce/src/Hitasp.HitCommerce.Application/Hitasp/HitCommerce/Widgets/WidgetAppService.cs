using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Widgets.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Widgets
{
    public class WidgetAppService : AsyncCrudAppService<Widget, WidgetDto, Guid,
        WidgetGetListInput, WidgetCreateOrEditDto, WidgetCreateOrEditDto>,
        IWidgetAppService
    {
        private readonly IWidgetRepository _repository;
        public WidgetAppService(IWidgetRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<WidgetDto>> GetPublishedAsync()
        {
            var widgets = await _repository.GetPublished();
            
            return new ListResultDto<WidgetDto>(ObjectMapper.Map<List<Widget>, List<WidgetDto>>(widgets));
        }
    }
}