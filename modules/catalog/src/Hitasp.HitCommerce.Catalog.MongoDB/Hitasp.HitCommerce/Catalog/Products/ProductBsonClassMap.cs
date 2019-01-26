using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public static class ProductBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Product>(
                    map =>
                    {
                        map.AutoMap();
                        map.SetIsRootClass(true);
                    }
                );

                BsonClassMap.RegisterClassMap<VirtualProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<PhysicalProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductAttributeCombination>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductCode>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductMeta>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductOrderingInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductPriceInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductPublishingInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductRate>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductShippingInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<StockQuantityHistory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<CrossSellProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductCategory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductDiscount>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductManufacturer>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductPicture>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductSpecificationAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductTag>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductWarehouseInventory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<RelatedProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<BackInStockSubscription>(map => { map.AutoMap(); });
            });
        }
    }
}