using System;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public interface IBrandTemplateAppService : IAsyncCrudAppService<BrandTemplateDto, Guid,
        BrandTemplateGetListInput, BrandTemplateCreateDto, BrandTemplateUpdateDto>
    {
        
    }
}