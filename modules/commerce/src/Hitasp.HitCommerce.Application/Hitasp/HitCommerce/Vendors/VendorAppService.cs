using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Vendors.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Vendors
{
    public class VendorAppService : AsyncCrudAppService<Vendor, VendorDto, Guid,
        VendorGetLitInput, VendorCreateDto, VendorUpdateDto> , IVendorAppService
    {
        private readonly IVendorRepository _repository;
        
        public VendorAppService(IVendorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<VendorDto>> GetActiveVendorsAsync()
        {
            var vendors = await _repository.GetActives();
            
            return new ListResultDto<VendorDto>(ObjectMapper.Map<List<Vendor>, List<VendorDto>>(vendors));
        }
    }
}