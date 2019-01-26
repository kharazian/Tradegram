using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Repositories;
using Volo.Abp.Domain.Services;


namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductFactory : DomainService, IProductFactory
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCodeRepository _codeRepository;
        private readonly IProductInfoRepository _infoRepository;
        private readonly IProductMetaRepository _metaRepository;
        private readonly IProductPriceInfoRepository _priceInfoRepository;
        private readonly IProductPublishingInfoRepository _publishingInfoRepository;
        private readonly IProductOrderingInfoRepository _orderingInfoRepository;
        private readonly IProductRateRepository _rateRepository;
        private readonly IProductShippingInfoRepository _shippingInfoRepository;


        public ProductFactory(IProductRepository productRepository, IProductCodeRepository codeRepository,
            IProductInfoRepository infoRepository, IProductMetaRepository metaRepository,
            IProductPriceInfoRepository priceInfoRepository,
            IProductPublishingInfoRepository publishingInfoRepository,
            IProductOrderingInfoRepository orderingInfoRepository, IProductRateRepository rateRepository,
            IProductShippingInfoRepository shippingInfoRepository)
        {
            _productRepository = productRepository;
            _codeRepository = codeRepository;
            _infoRepository = infoRepository;
            _metaRepository = metaRepository;
            _priceInfoRepository = priceInfoRepository;
            _publishingInfoRepository = publishingInfoRepository;
            _orderingInfoRepository = orderingInfoRepository;
            _rateRepository = rateRepository;
            _shippingInfoRepository = shippingInfoRepository;
        }

        public async Task<Product> CreatePhysicalProductAsync(Guid productTemplateId, string code, string name,
            string title, string shortDescription, decimal price, int stockQuantity)
        {
            if (await _codeRepository.IsCodeExistsAsync(code))
            {
                throw new ArgumentException($"A product with code: {code} has already exists!");
            }

            var productId = GuidGenerator.Create();

            var product = new PhysicalProduct(productId);
            
            product.SetProductTemplate(productTemplateId);
            product.AddStock(stockQuantity);

            var productCode = new ProductCode(productId, code);
            product.SetProductCode(await _codeRepository.InsertAsync(productCode));

            var productInfo = new ProductInfo(productId);
            productInfo.SetName(name);
            productInfo.SetTitle(title);
            productInfo.SetShortDescription(shortDescription);
            product.SetProductInfo(await _infoRepository.InsertAsync(productInfo));

            var productMeta = new ProductMeta(productId);
            product.SetProductMetaData(await _metaRepository.InsertAsync(productMeta));

            var productPrice = new ProductPriceInfo(productId, price);
            productPrice.SetAsTaxExempt();
            product.SetProductPriceInfo(await _priceInfoRepository.InsertAsync(productPrice));

            var productPublishingInfo = new ProductPublishingInfo(productId);
            product.SetProductPublishingInfo(await _publishingInfoRepository.InsertAsync(productPublishingInfo));

            var productOrderingInfo = new ProductOrderingInfo(productId);
            product.SetProductOrderingInfo(await _orderingInfoRepository.InsertAsync(productOrderingInfo));

            var productRate = new ProductRate(productId);
            product.SetProductRate(await _rateRepository.InsertAsync(productRate));

            var productShippingInfo = new ProductShippingInfo(productId);
            product.SetProductShippingInfo(await _shippingInfoRepository.InsertAsync(productShippingInfo));

            return await _productRepository.InsertAsync(product);
        }

        public async Task<Product> CreateVirtualProductAsync(Guid productTemplateId, string code, string name,
            string title, string shortDescription, decimal price)
        {
            if (await _codeRepository.IsCodeExistsAsync(code))
            {
                throw new ArgumentException($"A product with code: {code} has already exists!");
            }

            var productId = GuidGenerator.Create();

            var product = new VirtualProduct(productId);
            product.SetProductTemplate(productTemplateId);

            var productCode = new ProductCode(productId, code);
            product.SetProductCode(await _codeRepository.InsertAsync(productCode));

            var productInfo = new ProductInfo(productId);
            productInfo.SetName(name);
            productInfo.SetTitle(title);
            productInfo.SetShortDescription(shortDescription);
            product.SetProductInfo(await _infoRepository.InsertAsync(productInfo));

            var productMeta = new ProductMeta(productId);
            product.SetProductMetaData(await _metaRepository.InsertAsync(productMeta));

            var productPrice = new ProductPriceInfo(productId, price);
            productPrice.SetAsTaxExempt();
            product.SetProductPriceInfo(await _priceInfoRepository.InsertAsync(productPrice));

            var productPublishingInfo = new ProductPublishingInfo(productId);
            product.SetProductPublishingInfo(await _publishingInfoRepository.InsertAsync(productPublishingInfo));

            var productOrderingInfo = new ProductOrderingInfo(productId);
            product.SetProductOrderingInfo(await _orderingInfoRepository.InsertAsync(productOrderingInfo));

            var productRate = new ProductRate(productId);
            product.SetProductRate(await _rateRepository.InsertAsync(productRate));

            var productShippingInfo = new ProductShippingInfo(productId);
            product.SetProductShippingInfo(await _shippingInfoRepository.InsertAsync(productShippingInfo));

            return await _productRepository.InsertAsync(product);
        }
    }
}