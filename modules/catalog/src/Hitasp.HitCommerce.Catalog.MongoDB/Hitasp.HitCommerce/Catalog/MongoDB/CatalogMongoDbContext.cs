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
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public class CatalogMongoDbContext : AbpMongoDbContext, ICatalogMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        public IMongoCollection<ProductAttribute> ProductAttributes => Collection<ProductAttribute>();

        public IMongoCollection<PredefinedAttributeValue> PredefinedAttributeValues =>
            Collection<PredefinedAttributeValue>();

        public IMongoCollection<BackInStockSubscription> BackInStockSubscriptions =>
            Collection<BackInStockSubscription>();

        public IMongoCollection<Category> Categories => Collection<Category>();
        public IMongoCollection<CategoryDiscount> CategoryDiscounts => Collection<CategoryDiscount>();
        public IMongoCollection<Manufacturer> Manufacturers => Collection<Manufacturer>();
        public IMongoCollection<ManufacturerDiscount> ManufacturerDiscounts => Collection<ManufacturerDiscount>();
        public IMongoCollection<Product> Products => Collection<Product>();
        public IMongoCollection<VirtualProduct> VirtualProducts => Collection<VirtualProduct>();
        public IMongoCollection<PhysicalProduct> PhysicalProducts => Collection<PhysicalProduct>();

        public IMongoCollection<ProductAttributeCombination> ProductAttributeCombinations =>
            Collection<ProductAttributeCombination>();

        public IMongoCollection<ProductAttributeValue> ProductAttributeValues => Collection<ProductAttributeValue>();
        public IMongoCollection<StockQuantityHistory> StockQuantityHistories => Collection<StockQuantityHistory>();
        public IMongoCollection<CrossSellProduct> CrossSellProducts => Collection<CrossSellProduct>();
        public IMongoCollection<ProductCategory> ProductCategories => Collection<ProductCategory>();
        public IMongoCollection<ProductDiscount> ProductDiscounts => Collection<ProductDiscount>();

        public IMongoCollection<ProductProductAttribute> ProductProductAttributes =>
            Collection<ProductProductAttribute>();

        public IMongoCollection<ProductManufacturer> ProductManufacturers => Collection<ProductManufacturer>();
        public IMongoCollection<ProductPicture> ProductPictures => Collection<ProductPicture>();
        public IMongoCollection<ProductProductTag> ProductProductTags => Collection<ProductProductTag>();

        public IMongoCollection<ProductSpecificationAttribute> ProductSpecificationAttributes =>
            Collection<ProductSpecificationAttribute>();

        public IMongoCollection<ProductWarehouseInventory> ProductWarehouseInventories =>
            Collection<ProductWarehouseInventory>();

        public IMongoCollection<RelatedProduct> RelatedProducts => Collection<RelatedProduct>();
        public IMongoCollection<SpecificationAttribute> SpecificationAttributes => Collection<SpecificationAttribute>();

        public IMongoCollection<SpecificationAttributeOption> SpecificationAttributeOptions =>
            Collection<SpecificationAttributeOption>();

        public IMongoCollection<ProductTag> ProductTags => Collection<ProductTag>();
        public IMongoCollection<Template> Templates => Collection<Template>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAttributes(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureBackInStockSubscriptions(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureCategories(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureManufacturers(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureProducts(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureSpecificationAttributes(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureTagging(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureTemplates(options => { options.CollectionPrefix = CollectionPrefix; });
        }
    }
}