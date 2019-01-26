using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;
using Hitasp.HitCommerce.Catalog.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class BrandAppService : AsyncCrudAppService<Manufacturer, BrandDto, Guid,
        BrandGetListInput, BrandCreateDto, BrandUpdateDto>, IBrandAppService
    {
        private const string BrandEntityTypeId = "Brand";

        private readonly IUrlRecordService _urlRecordService;
        private readonly IThumbnailImageRepository _imageRepository;
        private readonly IBrandTemplateRepository _templateRepository;

        public BrandAppService(
            IBrandRepository repository,
            IUrlRecordService urlRecordService,
            IThumbnailImageRepository imageRepository,
            IBrandTemplateRepository templateRepository) : base(repository)
        {
            _urlRecordService = urlRecordService;
            _imageRepository = imageRepository;
            _templateRepository = templateRepository;
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
            await base.DeleteAsync(id);
            await _urlRecordService.RemoveAsync(id, BrandEntityTypeId);
        }

        public async Task<BrandWithDetailsDto> GetWithDetailAsync(Guid brandId)
        {
            var brand = await base.GetAsync(brandId);

            var brandTemplate = ObjectMapper.Map<BrandTemplate, BrandTemplateDto>(
                await _templateRepository.GetAsync(brand.BrandTemplateId)
            );

            var thumbnailImage = ObjectMapper.Map<ThumbnailImage, ThumbnailImageDto>(
                await _imageRepository.GetAsync(brand.PictureId)
            );

            return new BrandWithDetailsDto
            {
                Brand = brand,
                BrandTemplate = brandTemplate,
                ThumbnailImage = thumbnailImage
            };
        }
    }
}