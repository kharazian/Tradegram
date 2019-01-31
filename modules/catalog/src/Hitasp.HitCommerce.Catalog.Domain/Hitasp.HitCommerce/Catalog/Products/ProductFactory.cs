using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Exceptions;
using Hitasp.HitCommerce.Catalog.Products.Repositories;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductFactory : DomainService, IProductFactory
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCodeRepository _codeRepository;
        private readonly IProductInfoRepository _infoRepository;

        public ProductFactory(IProductRepository productRepository,
            IProductCodeRepository codeRepository,
            IProductInfoRepository infoRepository)
        {
            _productRepository = productRepository;
            _codeRepository = codeRepository;
            _infoRepository = infoRepository;
        }

        public async Task<Product> CreatePhysicalProductAsync(Guid productTemplateId, string code, string name,
            string title, string shortDescription, decimal price, int stockQuantity)
        {
            if (await _codeRepository.IsCodeExistsAsync(code))
            {
                throw new ProductCodeAlreadyExistsException(code);
            }

            if (await _infoRepository.FindByNameAsync(name) != null)
            {
                throw new ProductNameAlreadyExistsException(name);
            }

            var productId = GuidGenerator.Create();

            var product = new PhysicalProduct(productId);
            var productCode = new ProductCode(productId, code);
            var productInfo = new ProductInfo(productId);
            var productMetaInfo = new ProductMetaInfo(productId);
            var productPriceInfo = new ProductPriceInfo(productId, price);
            var productPublishingInfo = new ProductPublishingInfo(productId);
            var productOrderingInfo = new ProductOrderingInfo(productId);
            var productRate = new ProductRate(productId);
            var productShippingInfo = new ProductShippingInfo(productId);

            productInfo.SetName(name);
            productInfo.SetTitle(title);
            productInfo.SetShortDescription(shortDescription);
            productPriceInfo.SetAsTaxExempt();

            product.SetProductTemplate(productTemplateId);
            product.SetProductCode(productCode);
            product.SetProductInfo(productInfo);
            product.SetProductMetaInfo(productMetaInfo);
            product.SetProductPriceInfo(productPriceInfo);
            product.SetProductPublishingInfo(productPublishingInfo);
            product.SetProductOrderingInfo(productOrderingInfo);
            product.SetProductRate(productRate);
            product.SetProductShippingInfo(productShippingInfo);

            product.AddStock(stockQuantity);

            return await _productRepository.InsertAsync(product);
        }

        public async Task<Product> CreateVirtualProductAsync(Guid productTemplateId, string code, string name,
            string title, string shortDescription, decimal price)
        {
            if (await _codeRepository.IsCodeExistsAsync(code))
            {
                throw new ProductCodeAlreadyExistsException(code);
            }

            if (await _infoRepository.FindByNameAsync(name) != null)
            {
                throw new ProductNameAlreadyExistsException(name);
            }

            var productId = GuidGenerator.Create();

            var product = new VirtualProduct(productId);
            var productCode = new ProductCode(productId, code);
            var productInfo = new ProductInfo(productId);
            var productMetaInfo = new ProductMetaInfo(productId);
            var productPriceInfo = new ProductPriceInfo(productId, price);
            var productPublishingInfo = new ProductPublishingInfo(productId);
            var productOrderingInfo = new ProductOrderingInfo(productId);
            var productRate = new ProductRate(productId);
            var productShippingInfo = new ProductShippingInfo(productId);

            productInfo.SetName(name);
            productInfo.SetTitle(title);
            productInfo.SetShortDescription(shortDescription);
            productPriceInfo.SetAsTaxExempt();

            product.SetProductTemplate(productTemplateId);
            product.SetProductCode(productCode);
            product.SetProductInfo(productInfo);
            product.SetProductMetaInfo(productMetaInfo);
            product.SetProductPriceInfo(productPriceInfo);
            product.SetProductPublishingInfo(productPublishingInfo);
            product.SetProductOrderingInfo(productOrderingInfo);
            product.SetProductRate(productRate);
            product.SetProductShippingInfo(productShippingInfo);

            return await _productRepository.InsertAsync(product);
        }
    }
}