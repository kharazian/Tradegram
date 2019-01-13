﻿using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
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
        

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCatalog(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}