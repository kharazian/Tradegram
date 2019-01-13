using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [ConnectionStringName("Catalog")]
    public class CatalogDbContext : AbpDbContext<CatalogDbContext>, ICatalogDbContext
    {
        public static string TablePrefix { get; set; } = CatalogConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = CatalogConsts.DefaultDbSchema;


        public DbSet<Brand> Brands { get; set; }
        
        public DbSet<BrandTemplate> BrandTemplates { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<CategoryTemplate> CategoryTemplates { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<ProductTemplate> ProductTemplates { get; set; }
        
        public DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
        
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        
        public DbSet<ProductCategory> ProductCategories { get; set; }
        
        public DbSet<ProductLink> ProductLinks { get; set; }
        
        public DbSet<ProductOption> ProductOptions { get; set; }
        
        public DbSet<ProductOptionCombination> ProductOptionCombinations { get; set; }
        
        public DbSet<ProductPicture> ProductPictures { get; set; }
        
        public DbSet<ProductTag> ProductTags { get; set; }
        
        public DbSet<ProductTemplateAttribute> ProductTemplateAttributes { get; set; }
        
        public DbSet<ProductVendor> ProductVendors { get; set; }
        

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCatalog(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}