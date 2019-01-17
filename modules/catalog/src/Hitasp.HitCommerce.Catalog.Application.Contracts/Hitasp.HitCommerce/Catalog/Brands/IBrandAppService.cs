using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public interface IBrandAppService : IAsyncCrudAppService<BrandDto, Guid,
        BrandGetListInput, BrandCreateDto, BrandUpdateDto>
    {
        Task<BrandWithDetailsDto> GetWithDetailAsync(Guid brandId);
    }
}