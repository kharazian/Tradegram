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
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Tag = Hitasp.HitCommerce.Catalog.Tagging.Tag;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public class CatalogMongoDbContext : AbpMongoDbContext, ICatalogMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        public IMongoCollection<Manufacturer> Manufacturers => Collection<Manufacturer>();
        public IMongoCollection<ManufacturerInfo> ManufacturerInfos => Collection<ManufacturerInfo>();
        public IMongoCollection<ManufacturerMeta> ManufacturerMetas => Collection<ManufacturerMeta>();
        public IMongoCollection<ManufacturerPublishingInfo> ManufacturerPublishingInfos => Collection<ManufacturerPublishingInfo>();
        public IMongoCollection<Category> Categories => Collection<Category>();
        public IMongoCollection<CategoryInfo> CategoryInfos => Collection<CategoryInfo>();
        public IMongoCollection<CategoryMeta> CategoryMetas => Collection<CategoryMeta>();
        public IMongoCollection<CategoryPublishingInfo> CategoryPublishingInfos => Collection<CategoryPublishingInfo>();
        public IMongoCollection<VirtualProduct> VirtualProducts => Collection<VirtualProduct>();
        public IMongoCollection<PhysicalProduct> PhysicalProducts => Collection<PhysicalProduct>();
        public IMongoCollection<ProductCode> ProductCodes => Collection<ProductCode>();
        public IMongoCollection<ProductInfo> ProductInfos => Collection<ProductInfo>();
        public IMongoCollection<ProductMeta> ProductMetas => Collection<ProductMeta>();
        public IMongoCollection<ProductOrderingInfo> ProductOrderingInfos => Collection<ProductOrderingInfo>();
        public IMongoCollection<ProductPriceInfo> ProductPriceInfos => Collection<ProductPriceInfo>();
        public IMongoCollection<ProductPublishingInfo> ProductPublishingInfos => Collection<ProductPublishingInfo>();
        public IMongoCollection<ProductRate> ProductRates => Collection<ProductRate>();
        public IMongoCollection<ProductShippingInfo> ProductShippingInfos => Collection<ProductShippingInfo>();
        public IMongoCollection<StockQuantityHistory> StockQuantityHistories => Collection<StockQuantityHistory>();
        public IMongoCollection<CrossSellProduct> CrossSellProducts => Collection<CrossSellProduct>();
        public IMongoCollection<ProductAttribute> ProductAttributes => Collection<ProductAttribute>();
        public IMongoCollection<ProductCategory> ProductCategories => Collection<ProductCategory>();
        public IMongoCollection<ProductDiscount> ProductDiscounts => Collection<ProductDiscount>();
        public IMongoCollection<ProductManufacturer> ProductManufacturers => Collection<ProductManufacturer>();
        public IMongoCollection<ProductPicture> ProductPictures => Collection<ProductPicture>();
        public IMongoCollection<ProductSpecificationAttribute> ProductSpecificationAttributes => Collection<ProductSpecificationAttribute>();
        public IMongoCollection<ProductTag> ProductTags => Collection<ProductTag>();
        public IMongoCollection<ProductWarehouseInventory> ProductWarehouseInventories => Collection<ProductWarehouseInventory>();
        public IMongoCollection<RelatedProduct> RelatedProducts => Collection<RelatedProduct>();
        public IMongoCollection<BackInStockSubscription> BackInStockSubscriptions => Collection<BackInStockSubscription>();
        public IMongoCollection<Tag> Tags => Collection<Tag>();
        public IMongoCollection<Template> Templates => Collection<Template>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAttributes(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureTemplates(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureTagging(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureCategories(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureManufacturers(options => { options.CollectionPrefix = CollectionPrefix; });
            modelBuilder.ConfigureProducts(options => { options.CollectionPrefix = CollectionPrefix; });
        }
    }
}