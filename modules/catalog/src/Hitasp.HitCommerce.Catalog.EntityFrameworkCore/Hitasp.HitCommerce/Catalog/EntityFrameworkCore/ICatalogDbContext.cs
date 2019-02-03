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
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogDbContext : IEfCoreDbContext
    {
        DbSet<ProductAttribute> ProductAttributes { get; set; }

        DbSet<PredefinedAttributeValue> PredefinedAttributeValues { get; set; }

        DbSet<BackInStockSubscription> BackInStockSubscriptions { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<CategoryDiscount> CategoryDiscounts { get; set; }

        DbSet<Manufacturer> Manufacturers { get; set; }

        DbSet<ManufacturerDiscount> ManufacturerDiscounts { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<VirtualProduct> VirtualProducts { get; set; }

        DbSet<PhysicalProduct> PhysicalProducts { get; set; }

        DbSet<ProductAttributeCombination> ProductAttributeCombinations { get; set; }

        DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

        DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }

        DbSet<CrossSellProduct> CrossSellProducts { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<ProductDiscount> ProductDiscounts { get; set; }

        DbSet<ProductProductAttribute> ProductProductAttributes { get; set; }

        DbSet<ProductManufacturer> ProductManufacturers { get; set; }

        DbSet<ProductPicture> ProductPictures { get; set; }

        DbSet<ProductProductTag> ProductProductTags { get; set; }

        DbSet<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }

        DbSet<ProductWarehouseInventory> ProductWarehouseInventories { get; set; }

        DbSet<RelatedProduct> RelatedProducts { get; set; }

        DbSet<SpecificationAttribute> SpecificationAttributes { get; set; }

        DbSet<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }

        DbSet<ProductTag> ProductTags { get; set; }

        DbSet<Template> Templates { get; set; }
    }
}