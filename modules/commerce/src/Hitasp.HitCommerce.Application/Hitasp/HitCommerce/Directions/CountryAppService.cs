using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Directions
{
    public class CountryAppService : AsyncCrudAppService<Country, CountryDto, Guid, 
        CountryGetListInput, CountryCreateOrEditDto, CountryCreateOrEditDto>, ICountryAppService
    {
        private readonly ICountryRepository _repository;
        
        public CountryAppService(ICountryRepository repository) : base(repository)
        {
            _repository = repository;
        }
        
        //TODO: override GetListAsync to filter output by input options 
        
        public async Task<ListResultDto<CountryDto>> GetCountriesForBilling()
        {
            var billingAvailableCountries = await _repository.FindAllCountriesForBilling();

            return new ListResultDto<CountryDto>(
                    ObjectMapper.Map<List<Country>, List<CountryDto>>(billingAvailableCountries)
                );
        }

        public async Task<ListResultDto<CountryDto>> GetCountriesForShipping()
        {
            var shippingAvailableCountries = await _repository.FindAllCountriesForShipping();

            return new ListResultDto<CountryDto>(
                ObjectMapper.Map<List<Country>, List<CountryDto>>(shippingAvailableCountries)
            );
        }
    }
}