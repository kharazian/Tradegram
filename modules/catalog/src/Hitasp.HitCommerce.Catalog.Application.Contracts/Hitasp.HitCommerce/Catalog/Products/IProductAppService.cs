using System;
using Hitasp.HitCommerce.Catalog.Products.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, Guid,
        ProductGetListInput, ProductCreateOrUpdateDto>
    {
        
    }
}