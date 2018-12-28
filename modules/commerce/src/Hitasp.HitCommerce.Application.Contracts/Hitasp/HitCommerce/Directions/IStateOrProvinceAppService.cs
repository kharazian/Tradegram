using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface IStateOrProvinceAppService : IApplicationService
    {
        Task<PagedResultDto<StateOrProvinceDto>> GetListAsync(Guid countryId, PagedAndSortedResultRequestDto input);

        Task<StateOrProvinceDto> CreateAsync(StateOrProvinceCreateDto input);

        Task<StateOrProvinceDto> UpdateAsync(Guid id, StateOrProvinceUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}