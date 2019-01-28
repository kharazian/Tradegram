using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Manufacturers;
using Hitasp.HitCommerce.Catalog.Products;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes;
using Hitasp.HitCommerce.Catalog.Tagging;
using Hitasp.HitCommerce.Catalog.Templates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.DemoApp
{
    public class DemoAppDbContext : AbpDbContext<DemoAppDbContext>
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigureIdentity();
            modelBuilder.ConfigureAttributes();
            modelBuilder.ConfigureBackInStockSubscriptions();
            modelBuilder.ConfigureCategories();
            modelBuilder.ConfigureManufacturers();
            modelBuilder.ConfigureProducts();
            modelBuilder.ConfigureSpecificationAttributes();
            modelBuilder.ConfigureTagging();
            modelBuilder.ConfigureTemplates();
        }
    }
}