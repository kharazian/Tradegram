using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Hitasp.HitCommerce.Catalog.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, Guid,
        CategoryGetListInput, CategoryCreateDto, CategoryUpdateDto>, ICategoryAppService
    {
        private const string CategoryEntityTypeId = "Category";

        private readonly ICategoryRepository _repository;
        private readonly IUrlRecordService _urlRecordService;
        private readonly ICategoryTemplateRepository _templateRepository;
        private readonly IThumbnailImageRepository _imageRepository;

        public CategoryAppService(
            ICategoryRepository repository,
            IUrlRecordService urlRecordService,
            ICategoryTemplateRepository templateRepository,
            IThumbnailImageRepository imageRepository) : base(repository)
        {
            _repository = repository;
            _urlRecordService = urlRecordService;
            _templateRepository = templateRepository;
            _imageRepository = imageRepository;
        }


        public override async Task<CategoryDto> CreateAsync(CategoryCreateDto input)
        {
            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, CategoryEntityTypeId);

            var output = await base.CreateAsync(input);

            await _urlRecordService.AddAsync(output.Name, output.Slug, output.Id, CategoryEntityTypeId);

            return output;
        }

        public override async Task<CategoryDto> UpdateAsync(Guid id, CategoryUpdateDto input)
        {
            if (input.ParentCategoryId.HasValue && await HaveCircularNesting(id, input.ParentCategoryId.Value))
            {
                throw new AbpException("Parent category cannot be itself children");
            }

            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, CategoryEntityTypeId);

            var output = await base.UpdateAsync(id, input);

            await _urlRecordService.UpdateAsync(output.Name, output.Slug, output.Id, CategoryEntityTypeId);

            return output;
        }

        public override async Task DeleteAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);

            if (category.Children.Any(x => !x.IsDeleted))
            {
                throw new AbpException("Please make sure this category contains no children");
            }

            await base.DeleteAsync(id);
            await _urlRecordService.RemoveAsync(id, CategoryEntityTypeId);
        }

        public virtual async Task<PagedResultDto<CategoryListItemDto>> GetListItemsAsync(CategoryGetListInput input)
        {
            await CheckGetAllPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            var categoriesList = new List<CategoryListItemDto>();

            foreach (var category in entities)
            {
                var categoryListItem = new CategoryListItemDto
                {
                    Id = category.Id,
                    IsPublished = category.IsPublished,
                    IncludeInTopMenu = category.IncludeInTopMenu,
                    Name = category.Name,
                    DisplayOrder = category.DisplayOrder,
                    ParentCategoryId = category.ParentCategoryId
                };

                var parentCategory = category.ParentCategory;

                while (parentCategory != null)
                {
                    categoryListItem.Name = $"{parentCategory.Name} &#187; {categoryListItem.Name}";
                    parentCategory = parentCategory.ParentCategory;
                }

                categoriesList.Add(categoryListItem);
            }

            return new PagedResultDto<CategoryListItemDto>(
                totalCount,
                categoriesList
            );
        }

        public virtual async Task<CategoryWithDetailsDto> GetWithDetailsAsync(Guid categoryId)
        {
            var category = await base.GetAsync(categoryId);

            var categoryTemplate = ObjectMapper.Map<CategoryTemplate, CategoryTemplateDto>(
                await _templateRepository.GetAsync(category.CategoryTemplateId)
            );

            var parentCategory = new CategoryThumbnailDto();

            if (category.ParentCategoryId.HasValue)
            {
                parentCategory = ObjectMapper.Map<Category, CategoryThumbnailDto>(
                    await _repository.GetAsync(category.ParentCategoryId.Value)
                );
            }

            var children = ObjectMapper.Map<List<Category>, List<CategoryThumbnailDto>>(
                await _repository.GetListByParentIdAsync(category.Id)
            );

            var thumbnail = ObjectMapper.Map<ThumbnailImage, ThumbnailImageDto>(
                await _imageRepository.GetAsync(category.PictureId)
            );

            return new CategoryWithDetailsDto
            {
                Category = category,
                CategoryTemplate = categoryTemplate,
                Children = children,
                ThumbnailImage = thumbnail,
                ParentCategory = parentCategory
            };
        }

        private async Task<bool> HaveCircularNesting(Guid childId, Guid parentId)
        {
            var category = await _repository.GetAsync(parentId);

            var parentCategoryId = category.ParentCategoryId;

            while (parentCategoryId.HasValue)
            {
                if (parentCategoryId.Value == childId)
                {
                    return true;
                }

                var parentCategory = await _repository.GetAsync(parentCategoryId.Value);
                parentCategoryId = parentCategory.ParentCategoryId;
            }

            return false;
        }
    }
}