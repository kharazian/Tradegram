using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Vendors.Dtos;

namespace Hitasp.HitCommerce.Vendors
{
    public interface IVendorAppService : IApplicationService
    {
        Task<ListResultDto<VendorDto>> GetActiveVendorsAsync();
        
        Task<PagedResultDto<VendorDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<VendorDto> CreateAsync(VendorCreateDto input);

        Task<VendorDto> UpdateAsync(Guid id, VendorUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}