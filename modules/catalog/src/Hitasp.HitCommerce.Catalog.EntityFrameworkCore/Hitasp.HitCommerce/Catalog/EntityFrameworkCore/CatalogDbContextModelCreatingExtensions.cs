using System;
using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    public static class CatalogDbContextModelCreatingExtensions
    {
        public static void ConfigureCatalog(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<BrandTemplate>(b =>
            {
                b.ToTable(options.TablePrefix + "BrandTemplates", options.Schema);
                
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(BrandTemplate.Name));
                b.Property(x => x.ViewPath).HasColumnName(nameof(BrandTemplate.ViewPath));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(BrandTemplate.DisplayOrder));
            });
            
            builder.Entity<Brand>(b =>
            {
                b.ToTable(options.TablePrefix + "Brands", options.Schema);
                
                b.ConfigureAsContent();
                
                b.Property(x => x.BrandTemplateId).IsRequired().HasColumnName(nameof(Brand.BrandTemplateId));
                b.Property(x => x.PriceRanges).HasColumnName(nameof(Brand.PriceRanges));
                
                b.HasOne<BrandTemplate>().WithMany().IsRequired().HasForeignKey(x => x.BrandTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<CategoryTemplate>(b =>
            {
                b.ToTable(options.TablePrefix + "CategoryTemplates", options.Schema);
                
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(CategoryTemplate.Name));
                b.Property(x => x.ViewPath).HasColumnName(nameof(CategoryTemplate.ViewPath));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(CategoryTemplate.DisplayOrder));
            });
            
            builder.Entity<Category>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories", options.Schema);
                
                b.ConfigureAsContent();
                
                b.Property(x => x.CategoryTemplateId).IsRequired().HasColumnName(nameof(Category.CategoryTemplateId));
                b.Property(x => x.ParentCategoryId).HasColumnName(nameof(Category.ParentCategoryId));
                b.Property(x => x.PriceRanges).HasColumnName(nameof(Category.PriceRanges));
                b.Property(x => x.ShowOnHomePage).HasColumnName(nameof(Category.ShowOnHomePage));
                b.Property(x => x.IncludeInTopMenu).HasColumnName(nameof(Category.IncludeInTopMenu));
                
                b.HasOne<CategoryTemplate>().WithMany().IsRequired().HasForeignKey(x => x.CategoryTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                b.HasMany<Category>().WithOne().HasForeignKey(x => x.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}