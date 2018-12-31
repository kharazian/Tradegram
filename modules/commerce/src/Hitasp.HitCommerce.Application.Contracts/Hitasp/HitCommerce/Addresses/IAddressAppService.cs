using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Addresses
{
    public interface IAddressAppService : IApplicationService
    {
        Task<ListResultDto<AddressForViewDto>> GetListAsync(AddressGetAllDto input);

        Task<AddressForEditDto> GetForEditAsync(Guid id);

        Task<AddressForViewDto> CreateOrEditAsync(AddressCreateOrEditDto input);

        Task DeleteAsync(Guid id);
    }
}