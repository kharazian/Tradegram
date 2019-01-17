using System;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Hitasp.HitCommerce.Catalog.Products.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductTemplateAppService : IAsyncCrudAppService<ProductTemplateDto, Guid,
        ProductTemplateGetListInput, ProductTemplateCreateDto, ProductTemplateUpdateDto>
    {
        
    }
}