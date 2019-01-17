using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductAppService: IAsyncCrudAppService<ProductDto, Guid,
        ProductGetListInput, ProductCreateDto, ProductUpdateDto>
    {
        Task<PagedResultDto<ProductListItemDto>> GetListItemsAsync(ProductGetListInput input);
        
        Task<ListResultDto<ProductTinyDto>> GetProductListInCategoryAsync(Guid id);
        
        Task<ProductWithDetailsDto> GetWithDetailsAsync(Guid productId);
        
        Task<CalculatedProductPrice> CalculateProductPriceAsync(Guid productId);
    }
}