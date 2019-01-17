using System;
using Hitasp.HitCommerce.Catalog.Products.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductTemplateAppService: AsyncCrudAppService<ProductTemplate, ProductTemplateDto, Guid,
        ProductTemplateGetListInput, ProductTemplateCreateDto, ProductTemplateUpdateDto>, IProductTemplateAppService
    {
        public ProductTemplateAppService(IProductTemplateRepository repository) : base(repository)
        {
        }
    }
}