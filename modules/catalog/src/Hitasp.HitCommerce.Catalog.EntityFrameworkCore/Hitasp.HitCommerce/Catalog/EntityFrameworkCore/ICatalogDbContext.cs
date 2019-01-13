using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogDbContext : IEfCoreDbContext
    {
        DbSet<Brand> Brands { get; set; }

        DbSet<BrandTemplate> BrandTemplates { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<CategoryTemplate> CategoryTemplates { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductTemplate> ProductTemplates { get; set; }

        DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }

        DbSet<ProductAttribute> ProductAttributes { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<ProductLink> ProductLinks { get; set; }

        DbSet<ProductOption> ProductOptions { get; set; }

        DbSet<ProductOptionCombination> ProductOptionCombinations { get; set; }

        DbSet<ProductPicture> ProductPictures { get; set; }

        DbSet<ProductTag> ProductTags { get; set; }

        DbSet<ProductTemplateAttribute> ProductTemplateAttributes { get; set; }

        DbSet<ProductVendor> ProductVendors { get; set; }
    }
}