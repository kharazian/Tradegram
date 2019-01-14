using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Addresses
{
    public class AddressAppService : AsyncCrudAppService<Address, AddressDto, Guid,
        AddressGetListInput, AddressCreateDto, AddressUpdateDto>,
        IAddressAppService
    {
        private readonly IAddressRepository _addressRepository;

        
        public AddressAppService(IAddressRepository addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }
        
        public async Task<int> GetAddressTotalByCountryId(Guid countryId)
        {
            return await _addressRepository.GetAddressTotalByCountryId(countryId);
        }

        public async Task<int> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId)
        {
            return await _addressRepository.GetAddressTotalByStateOrProvinceId(stateOrProvinceId);
        }

        public async Task<int> GetAddressTotalByDistrictId(Guid districtId)
        {
            return await _addressRepository.GetAddressTotalByDistrictId(districtId);
        }
    }
}