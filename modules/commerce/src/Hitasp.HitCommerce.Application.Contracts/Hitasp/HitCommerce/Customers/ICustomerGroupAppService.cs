using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Customers.Dtos;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerGroupAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerGroupForViewDto>> GetListByCustomerIdAsync(CustomerGroupGetAllDto input);
        
        Task<PagedResultDto<CustomerGroupForViewDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<CustomerGroupForEditDto> GetForEditAsync(Guid id);

        Task<CustomerGroupForViewDto> CreateOrEditAsync(CustomerGroupCreateOrEditDto input);

        Task DeleteAsync(Guid id);
    }
}