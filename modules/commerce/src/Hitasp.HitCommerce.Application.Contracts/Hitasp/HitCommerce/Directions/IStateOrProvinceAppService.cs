using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface IStateOrProvinceAppService : IAsyncCrudAppService<StateOrProvinceDto, Guid,
        StateOrProvinceGetListInput, StateOrProvinceCreateDto, StateOrProvinceUpdateDto>
    {
        Task<ListResultDto<StateOrProvinceDto>> GetListByCountryId(Guid countryId);
    }
}