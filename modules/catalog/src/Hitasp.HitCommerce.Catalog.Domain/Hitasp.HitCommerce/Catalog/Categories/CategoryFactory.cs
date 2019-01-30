using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Exceptions;
using Hitasp.HitCommerce.Catalog.Categories.Repositories;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class CategoryFactory : DomainService, ICategoryFactory
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryFactory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategoryAsync(Guid categoryTemplateId, string name, string title)
        {
            if (await _categoryRepository.FindByNameAsync(name) != null)
            {
                throw new CategoryNameAlreadyExistsException(name);
            }

            var categoryId = GuidGenerator.Create();

            var category = new Category(
                categoryId,
                categoryTemplateId
            );

            var categoryInfo = new CategoryInfo(categoryId);
            var categoryMeta = new CategoryMetaInfo(categoryId);
            var categoryPageInfo = new CategoryPageInfo(categoryId);
            var publishingInfo = new CategoryPublishingInfo(categoryId);

            categoryInfo.SetName(name);
            categoryInfo.SetTitle(title);
            publishingInfo.SetAsPublished(false);

            category.SetCategoryInfo(categoryInfo);
            category.SetCategoryMetaInfo(categoryMeta);
            category.SetCategoryPageInfo(categoryPageInfo);
            category.SetCategoryPublishingInfo(publishingInfo);

            return await _categoryRepository.InsertAsync(category);
        }
    }
}