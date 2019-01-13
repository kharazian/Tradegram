using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
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
    }
}