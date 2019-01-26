using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Templates;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Tag = Hitasp.HitCommerce.Catalog.Tagging.Tag;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Manufacturer> Manufacturers { get; }
        
        IMongoCollection<ManufacturerInfo> ManufacturerInfos { get; }
        
        IMongoCollection<ManufacturerMeta> ManufacturerMetas { get; }
        
        IMongoCollection<ManufacturerPublishingInfo> ManufacturerPublishingInfos { get; }

        IMongoCollection<Category> Categories { get; }
        
        IMongoCollection<CategoryInfo> CategoryInfos { get; }
        
        IMongoCollection<CategoryMeta> CategoryMetas { get; }
        
        IMongoCollection<CategoryPublishingInfo> CategoryPublishingInfos { get; }

        IMongoCollection<VirtualProduct> VirtualProducts { get; }

        IMongoCollection<PhysicalProduct> PhysicalProducts { get; }
        
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
        
        IMongoCollection<ProductAttribute> ProductAttributes { get; }
        
        IMongoCollection<ProductCategory> ProductCategories { get; }
        
        IMongoCollection<ProductDiscount> ProductDiscounts { get; }
        
        IMongoCollection<ProductManufacturer> ProductManufacturers { get; }
        
        IMongoCollection<ProductPicture> ProductPictures { get; }
        
        IMongoCollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; }
        
        IMongoCollection<ProductTag> ProductTags { get; }
        
        IMongoCollection<ProductWarehouseInventory> ProductWarehouseInventories { get; }

        IMongoCollection<RelatedProduct> RelatedProducts { get; }
        
        IMongoCollection<BackInStockSubscription> BackInStockSubscriptions { get; }

        IMongoCollection<Tag> Tags { get; }
        
        IMongoCollection<Template> Templates { get; }
    }
}