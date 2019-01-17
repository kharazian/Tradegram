using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, Guid,
        CategoryGetListInput, CategoryCreateDto, CategoryUpdateDto>
    {
        Task<PagedResultDto<CategoryListItemDto>> GetListItemsAsync(CategoryGetListInput input);

        Task<CategoryWithDetailsDto> GetWithDetailsAsync(Guid categoryId);
    }
}