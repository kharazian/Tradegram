using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, Guid,
        ProductGetListInput, ProductCreateDto, ProductUpdateDto>, IProductAppService
    {
        private const string ProductEntityTypeId = "Product";

        private readonly IProductRepository _repository;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IProductCategoryRepository _productCategoryRepository;
        
        public ProductAppService(
            IProductRepository repository,
            IUrlRecordService urlRecordService, 
            IProductCategoryRepository productCategoryRepository) : base(repository)
        {
            _repository = repository;
            _urlRecordService = urlRecordService;
            _productCategoryRepository = productCategoryRepository;
        }

        public override async Task<ProductDto> CreateAsync(ProductCreateDto input)
        {
            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, ProductEntityTypeId);
            
            var output = await base.CreateAsync(input);
            
            await _urlRecordService.AddAsync(output.Name, output.Slug, output.Id, ProductEntityTypeId);

            return output;
        }

        public override async Task<ProductDto> UpdateAsync(Guid id, ProductUpdateDto input)
        {
            input.Slug = await _urlRecordService.ToSafeSlugAsync(input.Slug, ProductEntityTypeId);
            
            var output = await base.UpdateAsync(id, input);
            
            await _urlRecordService.UpdateAsync(output.Name, output.Slug, output.Id, ProductEntityTypeId);

            return output;
        }

        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
            
            await _urlRecordService.RemoveAsync(id, ProductEntityTypeId);
        }

        public async Task<PagedResultDto<ProductListItemDto>> GetListItemsAsync(ProductGetListInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<ProductTinyDto>> GetProductListInCategoryAsync(Guid id)
        {
            await CheckGetAllPolicyAsync();
            
            var productIds = await _productCategoryRepository.GetListByCategoryId(id);

            var products = await _repository.GetListAsync(productIds.Select(x => x.ProductId));
            
            return new ListResultDto<ProductTinyDto>(
                ObjectMapper.Map<List<Product>, List<ProductTinyDto>>(products)
            );
        }

        public async Task<ProductWithDetailsDto> GetWithDetailsAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<CalculatedProductPrice> CalculateProductPriceAsync(Guid productId)
        {
            var product = await base.GetAsync(productId);

            return CalculatePrice(product.Price, product.OldPrice, product.SpecialPrice,
                product.SpecialPriceStart, product.SpecialPriceEnd);
        }

        private static CalculatedProductPrice CalculatePrice(
            decimal price, decimal? oldPrice, decimal? specialPrice, DateTime? specialPriceStart,
            DateTime? specialPriceEnd)
        {
            var percentOfSaving = 0;
            var calculatedPrice = price;

            if (specialPrice.HasValue && specialPriceStart < DateTime.Now && DateTime.Now < specialPriceEnd)
            {
                calculatedPrice = specialPrice.Value;

                if (!oldPrice.HasValue || oldPrice < price)
                {
                    oldPrice = price;
                }
            }

            if (oldPrice.HasValue && oldPrice.Value > 0 && oldPrice > calculatedPrice)
            {
                percentOfSaving = (int)(100 - Math.Ceiling((calculatedPrice / oldPrice.Value) * 100));
            }

            return new CalculatedProductPrice
            {
                Price = calculatedPrice,
                OldPrice = oldPrice,
                PercentOfSaving = percentOfSaving
            }; 
        }
    }
}