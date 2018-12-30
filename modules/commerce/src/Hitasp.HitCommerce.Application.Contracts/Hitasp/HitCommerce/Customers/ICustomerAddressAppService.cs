using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Customers.Dtos;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerAddressAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerAddressForViewDto>> GetListAsync(CustomerAddressGetAllDto input);

        Task<CustomerAddressForEditDto> GetForEditAsync(Guid id);

        Task<CustomerAddressForViewDto> CreateOrEditAsync(CustomerAddressCreateOrEditDto input);

        Task SetAsDefaultAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}