using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Widgets.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Widgets
{
    public class WidgetInstanceAppService : AsyncCrudAppService<WidgetInstance, WidgetInstanceDto, Guid,
        WidgetInstanceGetListInput, WidgetInstanceCreateOrEditDto, WidgetInstanceCreateOrEditDto>,
        IWidgetInstanceAppService
    {
        private readonly IWidgetInstanceRepository _repository;
        public WidgetInstanceAppService(IWidgetInstanceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<WidgetInstanceDto>> GetPublishedAsync()
        {
            var widgets = await _repository.GetPublished();
            
            return new ListResultDto<WidgetInstanceDto>(ObjectMapper.Map<List<WidgetInstance>, List<WidgetInstanceDto>>(widgets));
        }

        public async Task<ListResultDto<WidgetInstanceDto>> GetListByWidgetId(Guid widgetId)
        {
            var widgets = await _repository.GetAllByWidgetId(widgetId);
            
            return new ListResultDto<WidgetInstanceDto>(ObjectMapper.Map<List<WidgetInstance>, List<WidgetInstanceDto>>(widgets));
        }

        public async Task<ListResultDto<WidgetInstanceDto>> GetListByWidgetZoneId(int widgetZoneId)
        {
            var widgets = await _repository.GetAllByWidgetZoneId(widgetZoneId);
            
            return new ListResultDto<WidgetInstanceDto>(ObjectMapper.Map<List<WidgetInstance>, List<WidgetInstanceDto>>(widgets));
        }

        public async Task<WidgetInstanceDto> GetByNameAsync(string name)
        {
            return MapToEntityDto(await _repository.FindByName(name));
        }
    }
}