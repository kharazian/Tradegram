using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface IDistrictAppService : IAsyncCrudAppService<DistrictDto, Guid,
        DistrictGetListInput, DistrictCreateOrEditDto, DistrictCreateOrEditDto>
    {
        Task<ListResultDto<DistrictDto>> GetListByStateOrProvinceId(Guid stateOrProvinceId);
    }
}