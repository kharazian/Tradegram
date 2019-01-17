using System;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class CategoryTemplateAppService: AsyncCrudAppService<CategoryTemplate, CategoryTemplateDto, Guid,
        CategoryTemplateGetListInput, CategoryTemplateCreateDto, CategoryTemplateUpdateDto>, ICategoryTemplateAppService
    {
        public CategoryTemplateAppService(ICategoryTemplateRepository repository) : base(repository)
        {
        }
    }
}