using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Aggregates;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<ProductAttribute> ProductAttributes { get; }

        IMongoCollection<PredefinedAttributeValue> PredefinedAttributeValues { get; }

        IMongoCollection<BackInStockSubscription> BackInStockSubscriptions { get; }

        IMongoCollection<Category> Categories { get; }

        IMongoCollection<CategoryInfo> CategoryInfos { get; }

        IMongoCollection<CategoryMeta> CategoryMetas { get; }

        IMongoCollection<CategoryPublishingInfo> CategoryPublishingInfos { get; }

        IMongoCollection<CategoryDiscount> CategoryDiscounts { get; }

        IMongoCollection<Manufacturer> Manufacturers { get; }

        IMongoCollection<ManufacturerInfo> ManufacturerInfos { get; }

        IMongoCollection<ManufacturerMeta> ManufacturerMetas { get; }

        IMongoCollection<ManufacturerPublishingInfo> ManufacturerPublishingInfos { get; }

        IMongoCollection<ManufacturerDiscount> ManufacturerDiscounts { get; }

        IMongoCollection<Product> Products { get; }

        IMongoCollection<VirtualProduct> VirtualProducts { get; }

        IMongoCollection<PhysicalProduct> PhysicalProducts { get; }

        IMongoCollection<ProductAttributeCombination> ProductAttributeCombinations { get; }

        IMongoCollection<ProductAttributeValue> ProductAttributeValues { get; }

        IMongoCollection<ProductCode> ProductCodes { get; }

        IMongoCollection<ProductInfo> ProductInfos { get; }

        IMongoCollection<ProductMeta> ProductMetas { get; }

        IMongoCollection<ProductOrderingInfo> ProductOrderingInfos { get; }

        IMongoCollection<ProductPriceInfo> ProductPriceInfos { get; }

        IMongoCollection<ProductPublishingInfo> ProductPublishingInfos { get; }

        IMongoCollection<ProductRate> ProductRates { get; }

        IMongoCollection<ProductShippingInfo> ProductShippingInfos { get; }

        IMongoCollection<StockQuantityHistory> StockQuantityHistories { get; }

        IMongoCollection<CrossSellProduct> CrossSellProducts { get; }

        IMongoCollection<ProductCategory> ProductCategories { get; }

        IMongoCollection<ProductDiscount> ProductDiscounts { get; }

        IMongoCollection<ProductProductAttribute> ProductProductAttributes { get; }

        IMongoCollection<ProductManufacturer> ProductManufacturers { get; }

        IMongoCollection<ProductPicture> ProductPictures { get; }

        IMongoCollection<ProductProductTag> ProductProductTags { get; }

        IMongoCollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; }

        IMongoCollection<ProductWarehouseInventory> ProductWarehouseInventories { get; }

        IMongoCollection<RelatedProduct> RelatedProducts { get; }

        IMongoCollection<SpecificationAttribute> SpecificationAttributes { get; }

        IMongoCollection<SpecificationAttributeOption> SpecificationAttributeOptions { get; }

        IMongoCollection<ProductTag> ProductTags { get; }

        IMongoCollection<Template> Templates { get; }
    }
}