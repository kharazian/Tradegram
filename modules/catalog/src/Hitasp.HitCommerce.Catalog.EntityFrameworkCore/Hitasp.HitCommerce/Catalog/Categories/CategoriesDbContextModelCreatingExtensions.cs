﻿using System;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
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

                b.HasOne<CategoryInfo>().WithOne().IsRequired().HasForeignKey<CategoryInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasOne<CategoryMetaInfo>().WithOne().IsRequired().HasForeignKey<CategoryMetaInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasOne<CategoryPageInfo>().WithOne().IsRequired().HasForeignKey<CategoryPageInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasOne<CategoryPublishingInfo>().WithOne().IsRequired().HasForeignKey<CategoryPublishingInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Template>().WithMany().IsRequired().HasForeignKey(x => x.CategoryTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany<CategoryDiscount>().WithOne().HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasMany<Category>().WithOne().HasForeignKey(x => x.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<CategoryInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories_Info", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength)
                    .HasColumnName(nameof(CategoryInfo.Name));
                b.Property(x => x.Title).IsRequired().HasMaxLength(CategoryConsts.MaxTitleLength)
                    .HasColumnName(nameof(CategoryInfo.Title));
                b.Property(x => x.Description).IsRequired(false).HasMaxLength(CategoryConsts.MaxDescriptionLength)
                    .HasColumnName(nameof(CategoryInfo.Description));
            });
            
            builder.Entity<CategoryMetaInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories_MetaInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.MetaTitle).IsRequired(false).HasMaxLength(CategoryConsts.MaxMetaTitleLength)
                    .HasColumnName(nameof(CategoryMetaInfo.MetaTitle));
                b.Property(x => x.MetaKeywords).IsRequired(false).HasMaxLength(CategoryConsts.MaxMetaKeywordsLength)
                    .HasColumnName(nameof(CategoryMetaInfo.MetaKeywords));
                b.Property(x => x.MetaDescription).IsRequired(false).HasMaxLength(CategoryConsts.MaxMetaDescriptionLength)
                    .HasColumnName(nameof(CategoryMetaInfo.MetaDescription));
            });
            
            builder.Entity<CategoryPageInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories_PageInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.PageSize).HasColumnName(nameof(CategoryPageInfo.PageSize));
                b.Property(x => x.IsAllowCustomersToSelectPageSize).HasDefaultValue(true)
                    .HasColumnName(nameof(CategoryPageInfo.IsAllowCustomersToSelectPageSize));
                b.Property(x => x.PageSizeOptions).HasColumnName(nameof(CategoryPageInfo.PageSizeOptions));
            });
            
            builder.Entity<CategoryPublishingInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories_PublishingInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.IsPublished).HasDefaultValue(false).HasColumnName(nameof(CategoryPublishingInfo.IsPublished));
                b.Property(x => x.ShowOnHomePage).HasDefaultValue(false).HasColumnName(nameof(CategoryPublishingInfo.ShowOnHomePage));
                b.Property(x => x.DisplayOrder).HasDefaultValue(0).HasColumnName(nameof(CategoryPublishingInfo.DisplayOrder));
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