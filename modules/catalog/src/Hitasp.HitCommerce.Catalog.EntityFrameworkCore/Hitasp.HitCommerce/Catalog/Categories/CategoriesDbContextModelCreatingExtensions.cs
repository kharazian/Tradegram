using System;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public static class CategoriesDbContextModelCreatingExtensions
    {
        public static void ConfigureCategories(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Category>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories", options.Schema);

                b.HasKey(x => x.Id);

                b.ConfigureFullAudited();
                b.ConfigureExtraProperties();

                b.Property(x => x.CategoryTemplateId).HasColumnName(nameof(Category.CategoryTemplateId));
                b.Property(x => x.PictureId).HasColumnName(nameof(Category.PictureId));
                b.Property(x => x.ParentCategoryId).HasColumnName(nameof(Category.ParentCategoryId));

                b.Property(x => x.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength)
                    .HasColumnName(nameof(Category.Name));
                b.Property(x => x.Title).IsRequired().HasMaxLength(CategoryConsts.MaxTitleLength)
                    .HasColumnName(nameof(Category.Title));
                b.Property(x => x.Description).IsRequired(false).HasMaxLength(CategoryConsts.MaxDescriptionLength)
                    .HasColumnName(nameof(Category.Description));
                
                b.Property(x => x.MetaTitle).IsRequired(false).HasMaxLength(CategoryConsts.MaxMetaTitleLength)
                    .HasColumnName(nameof(Category.MetaTitle));
                b.Property(x => x.MetaKeywords).IsRequired(false).HasMaxLength(CategoryConsts.MaxMetaKeywordsLength)
                    .HasColumnName(nameof(Category.MetaKeywords));
                b.Property(x => x.MetaDescription).IsRequired(false).HasMaxLength(CategoryConsts.MaxMetaDescriptionLength)
                    .HasColumnName(nameof(Category.MetaDescription));
                
                b.Property(x => x.PageSize).HasColumnName(nameof(Category.PageSize));
                b.Property(x => x.AllowCustomersToSelectPageSize).HasDefaultValue(true)
                    .HasColumnName(nameof(Category.AllowCustomersToSelectPageSize));
                b.Property(x => x.PageSizeOptions).HasColumnName(nameof(Category.PageSizeOptions));
                
                b.Property(x => x.IsPublished).HasDefaultValue(false).HasColumnName(nameof(Category.IsPublished));
                b.Property(x => x.ShowOnHomePage).HasDefaultValue(false).HasColumnName(nameof(Category.ShowOnHomePage));
                b.Property(x => x.DisplayOrder).HasDefaultValue(0).HasColumnName(nameof(Category.DisplayOrder));

                b.HasOne<Template>().WithMany().IsRequired().HasForeignKey(x => x.CategoryTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany<CategoryDiscount>().WithOne().HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                b.HasMany<Category>().WithOne().HasForeignKey(x => x.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<CategoryDiscount>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories_CategoryDiscount", options.Schema);

                b.Property(x => x.CategoryId).HasColumnName(nameof(CategoryDiscount.CategoryId));
                b.Property(x => x.DiscountId).HasColumnName(nameof(CategoryDiscount.DiscountId));

                b.HasKey(x => new { x.CategoryId, x.DiscountId });
            });
        }
    }
}