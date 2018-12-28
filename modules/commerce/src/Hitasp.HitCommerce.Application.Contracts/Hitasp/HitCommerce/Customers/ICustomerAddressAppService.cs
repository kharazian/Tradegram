using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Customers.Dtos;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerAddressAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerAddressOutputDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<CustomerAddressOutputDto> CreateAsync(CustomerAddressCreateDto input);

        Task SetAsDefault(Guid id);

        Task DeleteAsync(Guid id);
    }
}