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

        public ProductFactory(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreatePhysicalProductAsync(Guid productTemplateId, string code, string name,
            string title, string shortDescription, decimal price, int stockQuantity)
        {
            if (await _productRepository.IsCodeExistsAsync(code))
            {
                throw new ProductCodeAlreadyExistsException(code);
            }

            if (await _productRepository.FindByNameAsync(name) != null)
            {
                throw new ProductCodeAlreadyExistsException(code);
            }

            var productId = GuidGenerator.Create();

            var product = new PhysicalProduct(productId);
            var productCode = new ProductCode(productId, code);
            var productInfo = new ProductInfo(productId);
            var productMeta = new ProductMetaInfo(productId);
            var productPrice = new ProductPriceInfo(productId, price);
            var productPublishingInfo = new ProductPublishingInfo(productId);
            var productOrderingInfo = new ProductOrderingInfo(productId);
            var productRate = new ProductRate(productId);
            var productShippingInfo = new ProductShippingInfo(productId);

            productInfo.SetName(name);
            productInfo.SetTitle(title);
            productInfo.SetShortDescription(shortDescription);
            productPrice.SetAsTaxExempt();

            product.SetProductTemplate(productTemplateId);
            product.SetProductCode(productCode);
            product.SetProductInfo(productInfo);
            product.SetProductMetaInfo(productMeta);
            product.SetProductPriceInfo(productPrice);
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
            if (await _productRepository.IsCodeExistsAsync(code))
            {
                throw new ProductCodeAlreadyExistsException(code);
            }

            if (await _productRepository.FindByNameAsync(name) != null)
            {
                throw new ProductCodeAlreadyExistsException(code);
            }

            var productId = GuidGenerator.Create();

            var product = new VirtualProduct(productId);
            var productCode = new ProductCode(productId, code);
            var productInfo = new ProductInfo(productId);
            var productMeta = new ProductMetaInfo(productId);
            var productPrice = new ProductPriceInfo(productId, price);
            var productPublishingInfo = new ProductPublishingInfo(productId);
            var productOrderingInfo = new ProductOrderingInfo(productId);
            var productRate = new ProductRate(productId);
            var productShippingInfo = new ProductShippingInfo(productId);

            productInfo.SetName(name);
            productInfo.SetTitle(title);
            productInfo.SetShortDescription(shortDescription);
            productPrice.SetAsTaxExempt();

            product.SetProductTemplate(productTemplateId);
            product.SetProductCode(productCode);
            product.SetProductInfo(productInfo);
            product.SetProductMetaInfo(productMeta);
            product.SetProductPriceInfo(productPrice);
            product.SetProductPublishingInfo(productPublishingInfo);
            product.SetProductOrderingInfo(productOrderingInfo);
            product.SetProductRate(productRate);
            product.SetProductShippingInfo(productShippingInfo);

            return await _productRepository.InsertAsync(product);
        }
    }
}