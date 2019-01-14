using System;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, Guid,
        CategoryGetListInput, CategoryCreateDto, CategoryUpdateDto>
    {
        
    }
}