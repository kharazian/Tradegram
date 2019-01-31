using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, Guid,
        CategoryGetListInput, CategoryCreateOrUpdateDto>
    {
        Task<ListResultDto<CategoryDto>> GetListFilteredAsync(bool showHidden = false, bool loadCacheableCopy = true);

        Task<ListResultDto<CategoryDto>> GetListByParentIdAsync(Guid parentCategoryId, bool showHidden = false);

        Task<ListResultDto<CategoryDto>> GetListDisplayedOnHomePageAsync(bool showHidden = false);

        Task<ListResultDto<Guid>> GetListChildIdsAsync(Guid parentCategoryId, bool showHidden = false);

        Task<ListResultDto<CategoryDto>> GetListByIdsAsync(Guid[] categoryIds);

        Task<ListResultDto<CategoryDto>> GetListSortedForTreeAsync(Guid? parentId = null,
            bool ignoreCategoriesWithoutExistingParent = false);
        
        Task<string[]> GetNotExistingCategoriesAsync(string[] categoryIdsNames);

        Task<string> GetFormattedBreadCrumbAsync(Guid categoryId, string separator = ">>");

        Task<ListResultDto<CategoryDto>> GetBreadCrumbAsync(Guid? categoryId, bool showHidden = false);
    }
}