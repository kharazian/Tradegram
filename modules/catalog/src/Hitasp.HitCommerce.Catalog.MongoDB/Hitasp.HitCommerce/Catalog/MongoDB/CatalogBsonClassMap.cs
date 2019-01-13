using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
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
            });
        }
    }
}