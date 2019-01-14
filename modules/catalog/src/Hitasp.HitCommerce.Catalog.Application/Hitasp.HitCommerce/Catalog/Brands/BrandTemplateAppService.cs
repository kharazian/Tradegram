using System;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class BrandTemplateAppService: AsyncCrudAppService<BrandTemplate, BrandTemplateDto, Guid,
        BrandTemplateGetListInput, BrandTemplateCreateDto, BrandTemplateUpdateDto>, IBrandTemplateAppService
    {
        public BrandTemplateAppService(IBrandTemplateRepository repository) : base(repository)
        {
        }
    }
}