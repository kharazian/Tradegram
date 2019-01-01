using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Customers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerAddressAppService : IApplicationService
    {
        Task<ListResultDto<CustomerAddressDto>> GetListAsync(Guid customerId);

        Task<CustomerAddressDto> GetAsync(Guid addressId);

        Task DeleteAsync(Guid addressId);

        Task SetAsDefaultAsync(Guid addressId);
    }
}