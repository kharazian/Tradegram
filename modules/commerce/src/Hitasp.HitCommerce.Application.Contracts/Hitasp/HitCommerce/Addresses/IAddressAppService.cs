using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Addresses
{
    public interface IAddressAppService : IAsyncCrudAppService<AddressDto, Guid,
        AddressGetListInput, AddressCreateDto, AddressUpdateDto>
    {
        Task<int> GetAddressTotalByCountryId(Guid countryId);

        Task<int> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId);
        
        Task<int> GetAddressTotalByDistrictId(Guid districtId);
    }
}