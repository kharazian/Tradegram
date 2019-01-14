using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;
using Hitasp.HitCommon.Seo;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class BrandAppService : AsyncCrudAppService<Brand, BrandDto, Guid,
        BrandGetListInput, BrandCreateDto, BrandUpdateDto>, IBrandAppService
    {
        private const string BrandEntityTypeId = "Brand";
        
        private readonly IUrlRecordService _urlRecordService;
        
        public BrandAppService(
            IBrandRepository repository,
            IUrlRecordService urlRecordService) : base(repository)
        {
            _urlRecordService = urlRecordService;
        }

        public override async Task<BrandDto> CreateAsync(BrandCreateDto input)
        {
            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, BrandEntityTypeId);
            
            var output = await base.CreateAsync(input);
            
            await _urlRecordService.AddAsync(output.Name, output.Slug, output.Id, BrandEntityTypeId);

            return output;
        }

        public override async Task<BrandDto> UpdateAsync(Guid id, BrandUpdateDto input)
        {
            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, BrandEntityTypeId);
            
            var output = await base.UpdateAsync(id, input);
            
            await _urlRecordService.UpdateAsync(output.Name, output.Slug, output.Id, BrandEntityTypeId);

            return output;
        }

        public override async Task DeleteAsync(Guid id)
        {
            await _urlRecordService.RemoveAsync(id, BrandEntityTypeId);
            await base.DeleteAsync(id);
        }
    }
}