using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Customers.Dtos;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerGroupAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerGroupDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        
        Task<CustomerGroupDto> CreateAsync(CustomerGroupCreateDto input);

        Task<CustomerGroupDto> UpdateAsync(Guid id, CustomerGroupUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}