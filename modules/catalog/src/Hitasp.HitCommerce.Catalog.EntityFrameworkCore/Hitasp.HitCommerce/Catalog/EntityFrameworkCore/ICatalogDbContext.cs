using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Tagging;
using Hitasp.HitCommerce.Catalog.Templates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogDbContext : IEfCoreDbContext
    {
        DbSet<Manufacturer> Manufacturers { get; set; }
        
        DbSet<ManufacturerInfo> ManufacturerInfos { get; set; }
        
        DbSet<ManufacturerMeta> ManufacturerMetas { get; set; }
        
        DbSet<ManufacturerPublishingInfo> ManufacturerPublishingInfos { get; set; }

        DbSet<Category> Categories { get; set; }
        
        DbSet<CategoryInfo> CategoryInfos { get; set; }
        
        DbSet<CategoryMeta> CategoryMetas { get; set; }
        
        DbSet<CategoryPublishingInfo> CategoryPublishingInfos { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<VirtualProduct> VirtualProducts { get; set; }

        DbSet<PhysicalProduct> PhysicalProducts { get; set; }
        
        DbSet<ProductCode> ProductCodes { get; set; }
        
        DbSet<ProductInfo> ProductInfos { get; set; }
        
        DbSet<ProductMeta> ProductMetas { get; set; }
        
        DbSet<ProductOrderingInfo> ProductOrderingInfos { get; set; }
        
        DbSet<ProductPriceInfo> ProductPriceInfos { get; set; }
        
        DbSet<ProductPublishingInfo> ProductPublishingInfos { get; set; }
        
        DbSet<ProductRate> ProductRates { get; set; }
        
        DbSet<ProductShippingInfo> ProductShippingInfos { get; set; }
        
        DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }
        
        DbSet<CrossSellProduct> CrossSellProducts { get; set; }
        
        DbSet<ProductAttribute> ProductAttributes { get; set; }
        
        DbSet<ProductCategory> ProductCategories { get; set; }
        
        DbSet<ProductDiscount> ProductDiscounts { get; set; }
        
        DbSet<ProductManufacturer> ProductManufacturers { get; set; }
        
        DbSet<ProductPicture> ProductPictures { get; set; }
        
        DbSet<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
        
        DbSet<ProductTag> ProductTags { get; set; }
        
        DbSet<ProductWarehouseInventory> ProductWarehouseInventories { get; set; }

        DbSet<RelatedProduct> RelatedProducts { get; set; }

        DbSet<Tag> Tags { get; set; }
        
        DbSet<Template> Templates { get; set; }
    }
}