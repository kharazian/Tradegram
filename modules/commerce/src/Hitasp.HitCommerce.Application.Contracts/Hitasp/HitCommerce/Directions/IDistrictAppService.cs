using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface IDistrictAppService : IApplicationService
    {
        Task<PagedResultDto<DistrictDto>> GetListAsync(Guid stateOrProvinceId, PagedAndSortedResultRequestDto input);

        Task<DistrictDto> CreateAsync(DistrictCreateDto input);

        Task<DistrictDto> UpdateAsync(Guid id, DistrictUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}