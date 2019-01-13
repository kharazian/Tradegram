using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    public static class CatalogBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Brand>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<BrandTemplate>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Category>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<CategoryTemplate>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Product>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductTemplate>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductPriceHistory>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductAttribute>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductCategory>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductLink>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductOption>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductOptionCombination>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductPicture>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductTag>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductTemplateAttribute>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ProductVendor>(map =>
                {
                    map.AutoMap();
                });
            });
        }
    }
}