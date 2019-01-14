using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Directions
{
    public class StateOrProvinceAppService : AsyncCrudAppService<StateOrProvince, StateOrProvinceDto, Guid,
            StateOrProvinceGetListInput, StateOrProvinceCreateDto, StateOrProvinceUpdateDto>,
        IStateOrProvinceAppService
    {
        private readonly IStateOrProvinceRepository _repository;

        public StateOrProvinceAppService(IStateOrProvinceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<StateOrProvinceDto>> GetListByCountryId(Guid countryId)
        {
            var stats = await _repository.ListByCountryId(countryId);

            return new ListResultDto<StateOrProvinceDto>(
                ObjectMapper.Map<List<StateOrProvince>, List<StateOrProvinceDto>>(stats));
        }
    }
}