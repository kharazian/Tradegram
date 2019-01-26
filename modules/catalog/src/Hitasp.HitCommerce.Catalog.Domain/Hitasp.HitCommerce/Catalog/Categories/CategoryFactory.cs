using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Repositories;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class CategoryFactory : DomainService, ICategoryFactory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryInfoRepository _infoRepository;
        private readonly ICategoryMetaRepository _metaRepository;
        private readonly ICategoryPublishingInfoRepository _publishingInfoRepository;

        public CategoryFactory(
            ICategoryRepository categoryRepository,
            ICategoryInfoRepository infoRepository,
            ICategoryMetaRepository metaRepository,
            ICategoryPublishingInfoRepository publishingInfoRepository)
        {
            _categoryRepository = categoryRepository;
            _infoRepository = infoRepository;
            _metaRepository = metaRepository;
            _publishingInfoRepository = publishingInfoRepository;
        }

        public async Task<Category> CreateCategoryAsync(Guid categoryTemplateId, string name, string title)
        {
            var categoryId = GuidGenerator.Create();

            var category = new Category(
                categoryId,
                categoryTemplateId
            );

            var categoryInfo = new CategoryInfo(categoryId);
            categoryInfo.SetName(name);
            categoryInfo.SetTitle(title);
            category.SetCategoryInfo(await _infoRepository.InsertAsync(categoryInfo));

            var categoryMeta = new CategoryMeta(categoryId);
            category.SetCategoryMeta(await _metaRepository.InsertAsync(categoryMeta));

            var publishingInfo = new CategoryPublishingInfo(categoryId);
            category.SetCategoryPublishingInfo(await _publishingInfoRepository.InsertAsync(publishingInfo));

            return await _categoryRepository.InsertAsync(category);
        }
    }
}