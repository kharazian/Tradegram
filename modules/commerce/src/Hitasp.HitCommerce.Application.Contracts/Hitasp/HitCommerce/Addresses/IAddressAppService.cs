using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Addresses
{
    public interface IAddressAppService : IApplicationService
    {
        Task<PagedResultDto<AddressWithDetailDto>> GetListAsync(AddressGetListInput input);

        Task<AddressForEditOutput> GetForEditAsync(Guid addressId);

        Task<AddressWithDetailDto> CreateOrEditAsync(AddressCreateOrEditDto input);

        Task DeleteAsync(Guid addressId);
        
        Task<AddressReportRequestOutput> GetAddressTotalByCountryId(Guid countryId);

        Task<AddressReportRequestOutput> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId);
        
        Task<AddressReportRequestOutput> GetAddressTotalByDistrictId(Guid districtId);
    }
}