using System;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryTemplateAppService : IAsyncCrudAppService<CategoryTemplateDto, Guid,
        CategoryTemplateGetListInput, CategoryTemplateCreateDto, CategoryTemplateUpdateDto>
    {
        
    }
}