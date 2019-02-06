using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Tagging.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public interface IProductTagAppService : IAsyncCrudAppService<ProductTagDto, Guid,
        ProductTagGetListInput, ProductTagCreateOrUpdateDto>
    {
        Task<ListResultDto<PopularTagDto>> GetPopularTagsAsync(ProductTagGetPopularsInput input);
    }
}
