using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface ICountryAppService : IApplicationService
    {
        Task<PagedResultDto<CountryDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<CountryDto> CreateAsync(CountryCreateDto input);

        Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}