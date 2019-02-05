using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Manufacturers;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.Products;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Hitasp.HitCommerce.Catalog.Tagging;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Hitasp.HitCommerce.Catalog.Templates;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
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

        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<PredefinedAttributeValue> PredefinedAttributeValues { get; set; }
        public DbSet<BackInStockSubscription> BackInStockSubscriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ManufacturerDiscount> ManufacturerDiscounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Downloadable> Downloadables { get; set; }
        public DbSet<Servicable> Servicables { get; set; }
        public DbSet<Shippable> Shippables { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<ProductBasePrice> ProductBasePrices { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<ProductPricing> ProductPricings { get; set; }
        public DbSet<ProductShipping> ProductShippings { get; set; }
        public DbSet<ProductAttributeCombination> ProductAttributeCombinations { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }
        public DbSet<CrossSellProduct> CrossSellProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductProductAttribute> ProductProductAttributes { get; set; }
        public DbSet<ProductManufacturer> ProductManufacturers { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductProductTag> ProductProductTags { get; set; }
        public DbSet<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
        public DbSet<ProductWarehouseInventory> ProductWarehouseInventories { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<RequiredProduct> RequiredProducts { get; set; }
        public DbSet<SpecificationAttribute> SpecificationAttributes { get; set; }
        public DbSet<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
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
            
            builder.ConfigureBackInStockSubscriptions(options =>
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
            
            builder.ConfigureSpecificationAttributes(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureTagging(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
            
            builder.ConfigureTemplates(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}