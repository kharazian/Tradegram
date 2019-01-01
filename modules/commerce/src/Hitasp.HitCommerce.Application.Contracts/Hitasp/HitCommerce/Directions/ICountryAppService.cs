using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface ICountryAppService : IAsyncCrudAppService<CountryDto, Guid, 
        CountryGetListInput, CountryCreateOrEditDto, CountryCreateOrEditDto>
    {
        Task<ListResultDto<CountryDto>> GetCountriesForBilling();
        
        Task<ListResultDto<CountryDto>> GetCountriesForShipping();
    }
}