using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public class CatalogMongoDbContext : AbpMongoDbContext, ICatalogMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        public IMongoCollection<Brand> Brands => Collection<Brand>();

        public IMongoCollection<BrandTemplate> BrandTemplates => Collection<BrandTemplate>();

        public IMongoCollection<Category> Categories => Collection<Category>();

        public IMongoCollection<CategoryTemplate> CategoryTemplates => Collection<CategoryTemplate>();
        
        public IMongoCollection<Product> Products => Collection<Product>();
        
        public IMongoCollection<ProductTemplate> ProductTemplates => Collection<ProductTemplate>();
        
        public IMongoCollection<ProductPriceHistory> ProductPriceHistories => Collection<ProductPriceHistory>();
        
        public IMongoCollection<ProductAttribute> ProductAttributes => Collection<ProductAttribute>();
        
        public IMongoCollection<ProductCategory> ProductCategories => Collection<ProductCategory>();
        
        public IMongoCollection<ProductLink> ProductLinks => Collection<ProductLink>();
        
        public IMongoCollection<ProductOption> ProductOptions => Collection<ProductOption>();

        public IMongoCollection<ProductOptionCombination> ProductOptionCombinations =>
            Collection<ProductOptionCombination>();

        public IMongoCollection<ProductPicture> ProductPictures => Collection<ProductPicture>();
        
        public IMongoCollection<ProductTag> ProductTags => Collection<ProductTag>();

        public IMongoCollection<ProductTemplateAttribute> ProductTemplateAttributes =>
            Collection<ProductTemplateAttribute>();

        public IMongoCollection<ProductVendor> ProductVendors => Collection<ProductVendor>();


        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCatalog(options => { options.CollectionPrefix = CollectionPrefix; });
        }
    }
}