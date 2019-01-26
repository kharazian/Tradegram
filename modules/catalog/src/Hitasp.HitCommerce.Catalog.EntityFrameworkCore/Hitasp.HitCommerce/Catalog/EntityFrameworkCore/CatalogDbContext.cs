using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Products;
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
    public class CatalogDbContext : AbpDbContext<CatalogDbContext>, ICatalogDbContext
    {
        public static string TablePrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = CatalogConsts.DefaultDbSchema;

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ManufacturerInfo> ManufacturerInfos { get; set; }
        public DbSet<ManufacturerMeta> ManufacturerMetas { get; set; }
        public DbSet<ManufacturerPublishingInfo> ManufacturerPublishingInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryInfo> CategoryInfos { get; set; }
        public DbSet<CategoryMeta> CategoryMetas { get; set; }
        public DbSet<CategoryPublishingInfo> CategoryPublishingInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<VirtualProduct> VirtualProducts { get; set; }
        public DbSet<PhysicalProduct> PhysicalProducts { get; set; }
        public DbSet<ProductCode> ProductCodes { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<ProductMeta> ProductMetas { get; set; }
        public DbSet<ProductOrderingInfo> ProductOrderingInfos { get; set; }
        public DbSet<ProductPriceInfo> ProductPriceInfos { get; set; }
        public DbSet<ProductPublishingInfo> ProductPublishingInfos { get; set; }
        public DbSet<ProductRate> ProductRates { get; set; }
        public DbSet<ProductShippingInfo> ProductShippingInfos { get; set; }
        public DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }
        public DbSet<CrossSellProduct> CrossSellProducts { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductManufacturer> ProductManufacturers { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductWarehouseInventory> ProductWarehouseInventories { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Template> Templates { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            builder.ConfigureAttributes(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureCategories(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureManufacturers(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureProducts(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureTemplates(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureTagging(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}