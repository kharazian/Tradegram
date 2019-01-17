using System;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Hitasp.HitCommon.Seo;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, Guid,
        CategoryGetListInput, CategoryCreateDto, CategoryUpdateDto>, ICategoryAppService
    {
        private const string CategoryEntityTypeId = "Category";
        
        private readonly IUrlRecordService _urlRecordService;
        
        public CategoryAppService(ICategoryRepository repository, IUrlRecordService urlRecordService) : base(repository)
        {
            _urlRecordService = urlRecordService;
        }

        public override async Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryGetListInput input)
        {
            await CheckGetAllPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            var output = entities.Select(MapToEntityDto).ToList();

            foreach (var category in output)
            {
                var parentCategory = category.ParentCategory;
                while (parentCategory != null)
                {
                    category.Name = $"{parentCategory.Name} >> {category.Name}";
                    parentCategory = parentCategory.ParentCategory;
                }
            }

            return new PagedResultDto<CategoryDto>(
                totalCount,
                output
            );
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
            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, CategoryEntityTypeId);
            
            var output = await base.UpdateAsync(id, input);
            
            await _urlRecordService.UpdateAsync(output.Name, output.Slug, output.Id, CategoryEntityTypeId);

            return output;
        }

        public override async Task DeleteAsync(Guid id)
        {
            await _urlRecordService.RemoveAsync(id, CategoryEntityTypeId);
            await base.DeleteAsync(id);
        }
    }
}