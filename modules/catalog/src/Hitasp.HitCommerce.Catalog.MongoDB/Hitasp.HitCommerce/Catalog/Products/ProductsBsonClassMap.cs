﻿using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public static class ProductsBsonClassMap
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

                BsonClassMap.RegisterClassMap<Shippable>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<Servicable>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<Downloadable>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductBasePrice>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductInventory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductPricing>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductShipping>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductProductAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductAttributeCombination>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<StockQuantityHistory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<CrossSellProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductCategory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductDiscount>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductManufacturer>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductPicture>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductSpecificationAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductProductTag>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ProductWarehouseInventory>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<RelatedProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<RequiredProduct>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<BackInStockSubscription>(map => { map.AutoMap(); });
            });
        }
    }
}