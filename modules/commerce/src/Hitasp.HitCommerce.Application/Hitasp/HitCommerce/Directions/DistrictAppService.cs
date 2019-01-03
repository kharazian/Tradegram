using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Directions
{
    public class DistrictAppService : AsyncCrudAppService<District, DistrictDto, Guid,
        DistrictGetListInput, DistrictCreateOrEditDto, DistrictCreateOrEditDto>, IDistrictAppService
    {
        private readonly IDistrictRepository _repository;
        public DistrictAppService(IDistrictRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<DistrictDto>> GetListByStateOrProvinceId(Guid stateOrProvinceId)
        {
            var districts = await _repository.ListByStateOrProvinceId(stateOrProvinceId);
            
            return new ListResultDto<DistrictDto>(ObjectMapper.Map<List<District>, List<DistrictDto>>(districts));
        }
    }
}