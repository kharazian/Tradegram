using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Brand> Brands { get; }

        IMongoCollection<BrandTemplate> BrandTemplates { get; }
        
        IMongoCollection<Category> Categories { get; }

        IMongoCollection<CategoryTemplate> CategoryTemplates { get; }
        
        IMongoCollection<Product> Products { get;}

        IMongoCollection<ProductTemplate> ProductTemplates { get;}

        IMongoCollection<ProductPriceHistory> ProductPriceHistories { get;}

        IMongoCollection<ProductAttribute> ProductAttributes { get;}

        IMongoCollection<ProductCategory> ProductCategories { get;}

        IMongoCollection<ProductLink> ProductLinks { get;}

        IMongoCollection<ProductOption> ProductOptions { get;}

        IMongoCollection<ProductOptionCombination> ProductOptionCombinations { get;}

        IMongoCollection<ProductPicture> ProductPictures { get;}

        IMongoCollection<ProductTag> ProductTags { get;}

        IMongoCollection<ProductTemplateAttribute> ProductTemplateAttributes { get;}

        IMongoCollection<ProductVendor> ProductVendors { get;}
    }
}