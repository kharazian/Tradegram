using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
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

    }
}