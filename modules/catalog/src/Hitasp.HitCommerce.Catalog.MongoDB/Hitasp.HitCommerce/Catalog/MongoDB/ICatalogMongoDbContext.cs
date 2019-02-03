using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
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

        IMongoCollection<CategoryDiscount> CategoryDiscounts { get; }

        IMongoCollection<Manufacturer> Manufacturers { get; }

        IMongoCollection<ManufacturerDiscount> ManufacturerDiscounts { get; }

        IMongoCollection<Product> Products { get; }

        IMongoCollection<VirtualProduct> VirtualProducts { get; }

        IMongoCollection<PhysicalProduct> PhysicalProducts { get; }

        IMongoCollection<ProductAttributeCombination> ProductAttributeCombinations { get; }

        IMongoCollection<ProductAttributeValue> ProductAttributeValues { get; }

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