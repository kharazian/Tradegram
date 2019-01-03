using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Addresses
{
    public interface IAddressRepository : IRepository<Address, Guid>
    {
        Task<int> GetAddressTotalByCountryId(Guid countryId);

        Task<int> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId);
        
        Task<int> GetAddressTotalByDistrictId(Guid districtId);
    }
}