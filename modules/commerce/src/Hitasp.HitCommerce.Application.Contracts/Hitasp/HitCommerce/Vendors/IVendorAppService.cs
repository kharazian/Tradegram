using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Vendors.Dtos;

namespace Hitasp.HitCommerce.Vendors
{
    public interface IVendorAppService : IAsyncCrudAppService<VendorDto, Guid,
        VendorGetLitInput, VendorCreateOrEditDto, VendorCreateOrEditDto>
    {
        Task<ListResultDto<VendorDto>> GetActiveVendorsAsync();
    }
}