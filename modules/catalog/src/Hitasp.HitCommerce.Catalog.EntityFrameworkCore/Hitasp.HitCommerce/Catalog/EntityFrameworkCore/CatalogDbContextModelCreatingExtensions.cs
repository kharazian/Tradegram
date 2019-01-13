using System;
using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

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
            
            builder.Entity<ProductTemplate>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductTemplates", options.Schema);
                
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ProductTemplate.Name));
                b.Property(x => x.ViewPath).HasColumnName(nameof(ProductTemplate.ViewPath));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductTemplate.DisplayOrder));

                b.HasMany<ProductTemplateAttribute>().WithOne().HasForeignKey(x => x.ProductTemplateId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            builder.Entity<Product>(b =>
            {
                b.ToTable(options.TablePrefix + "Products", options.Schema);
                
                b.ConfigureAsContent();
                
                
                b.Property(x => x.ShortDescription).IsRequired().HasColumnName(nameof(Product.ShortDescription));
                b.Property(x => x.Price).IsRequired().HasColumnName(nameof(Product.Price));
                b.Property(x => x.OldPrice).HasColumnName(nameof(Product.OldPrice));
                b.Property(x => x.SpecialPrice).HasColumnName(nameof(Product.SpecialPrice));
                b.Property(x => x.SpecialPriceStart).HasColumnName(nameof(Product.SpecialPriceStart));
                b.Property(x => x.SpecialPriceEnd).HasColumnName(nameof(Product.SpecialPriceEnd));
                b.Property(x => x.IsAllowedCustomerEntersPrice).HasColumnName(nameof(Product.IsAllowedCustomerEntersPrice));
                b.Property(x => x.MinimumCustomerEnteredPrice).HasColumnName(nameof(Product.MinimumCustomerEnteredPrice));
                b.Property(x => x.MaximumCustomerEnteredPrice).HasColumnName(nameof(Product.MaximumCustomerEnteredPrice));
                b.Property(x => x.HasOptions).HasColumnName(nameof(Product.HasOptions));
                b.Property(x => x.IsVisibleIndividually).HasColumnName(nameof(Product.IsVisibleIndividually));
                b.Property(x => x.IsFeatured).HasColumnName(nameof(Product.IsFeatured));
                b.Property(x => x.IsCallForPricing).HasColumnName(nameof(Product.IsCallForPricing));
                b.Property(x => x.IsAllowToOrder).HasColumnName(nameof(Product.IsAllowToOrder));
                b.Property(x => x.StockTrackingIsEnabled).HasColumnName(nameof(Product.StockTrackingIsEnabled));
                b.Property(x => x.Sku).HasColumnName(nameof(Product.Sku));
                b.Property(x => x.Gtin).HasColumnName(nameof(Product.Gtin));
                b.Property(x => x.StockQuantity).HasColumnName(nameof(Product.StockQuantity));
                b.Property(x => x.RestockThreshold).HasColumnName(nameof(Product.RestockThreshold));
                b.Property(x => x.MaxStockThreshold).HasColumnName(nameof(Product.MaxStockThreshold));
                b.Property(x => x.OnReorder).HasColumnName(nameof(Product.OnReorder));
                b.Property(x => x.NormalizedName).IsRequired().HasColumnName(nameof(Product.NormalizedName));
                b.Property(x => x.ReviewsCount).HasColumnName(nameof(Product.ReviewsCount));
                b.Property(x => x.RatingAverage).HasColumnName(nameof(Product.RatingAverage));
                b.Property(x => x.BrandId).HasColumnName(nameof(Product.BrandId));
                b.Property(x => x.TaxClassId).HasColumnName(nameof(Product.TaxClassId));
                b.Property(x => x.ProductTemplateId).IsRequired().HasColumnName(nameof(Product.ProductTemplateId));

                
                b.HasOne<ProductTemplate>().WithMany().IsRequired().HasForeignKey(x => x.ProductTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                b.HasOne<Brand>().WithMany().HasForeignKey(x => x.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany<ProductPriceHistory>().WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany<ProductLink>().WithOne().HasForeignKey(x => x.ProductId);
                
                b.HasMany(x => x.Pictures).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.AttributeValues).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.OptionValues).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.OptionCombinations).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.Categories).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.Tags).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.Vendors).WithOne().HasForeignKey(x => x.ProductId);
                b.HasMany(x => x.Tags).WithOne().HasForeignKey(x => x.ProductId);
            });
            
            builder.Entity<ProductAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductAttributes", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductAttribute.ProductId));
                b.Property(x => x.AttributeId).HasColumnName(nameof(ProductAttribute.AttributeId));

                b.HasKey(x => new { x.ProductId, x.AttributeId });
            });
            
            builder.Entity<ProductCategory>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductCategories", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductCategory.ProductId));
                b.Property(x => x.CategoryId).HasColumnName(nameof(ProductCategory.CategoryId));
                b.Property(x => x.IsFeaturedProduct).HasColumnName(nameof(ProductCategory.IsFeaturedProduct));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductCategory.DisplayOrder));

                b.HasKey(x => new { x.ProductId, x.CategoryId });
            });

            builder.Entity<ProductLink>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductLinks", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductLink.ProductId));
                b.Property(x => x.LinkedProductId).HasColumnName(nameof(ProductLink.LinkedProductId));

                b.Property(x => x.LinkType).HasColumnName(nameof(ProductLink.LinkType));

                b.HasKey(x => new { x.ProductId, x.LinkedProductId });
                
                b.HasOne<Product>().WithMany(p => p.ProductLinks).HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne<Product>().WithMany(p => p.LinkedProductLinks).HasForeignKey(x => x.LinkedProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<ProductOption>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductOptions", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductOption.ProductId));
                b.Property(x => x.OptionId).HasColumnName(nameof(ProductOption.OptionId));
                b.Property(x => x.Value).HasColumnName(nameof(ProductOption.Value));
                b.Property(x => x.DisplayType).HasColumnName(nameof(ProductOption.DisplayType));
                b.Property(x => x.SortIndex).HasColumnName(nameof(ProductOption.SortIndex));

                b.HasKey(x => new { x.ProductId, x.OptionId });
            });
            
            builder.Entity<ProductOptionCombination>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductOptionCombinations", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductOptionCombination.ProductId));
                b.Property(x => x.OptionId).HasColumnName(nameof(ProductOptionCombination.OptionId));
                b.Property(x => x.Value).HasColumnName(nameof(ProductOptionCombination.Value));
                b.Property(x => x.SortIndex).HasColumnName(nameof(ProductOptionCombination.SortIndex));

                b.HasKey(x => new { x.ProductId, x.OptionId });
            });
            
            builder.Entity<ProductPicture>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductPictures", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductPicture.ProductId));
                b.Property(x => x.PictureId).HasColumnName(nameof(ProductPicture.PictureId));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductPicture.DisplayOrder));

                b.HasKey(x => new { x.ProductId, x.PictureId });
            });
            
            builder.Entity<ProductPriceHistory>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductPriceHistories", options.Schema);

                b.Property(x => x.ProductId).IsRequired().HasColumnName(nameof(ProductPriceHistory.ProductId));
                b.Property(x => x.Price).IsRequired().HasColumnName(nameof(ProductPriceHistory.Price));
                b.Property(x => x.OldPrice).HasColumnName(nameof(ProductPriceHistory.OldPrice));
                b.Property(x => x.SpecialPrice).HasColumnName(nameof(ProductPriceHistory.SpecialPrice));
                b.Property(x => x.SpecialPriceStart).HasColumnName(nameof(ProductPriceHistory.SpecialPriceStart));
                b.Property(x => x.SpecialPriceEnd).HasColumnName(nameof(ProductPriceHistory.SpecialPriceEnd));
                
                b.HasOne<Product>().WithMany().IsRequired().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<ProductTag>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductTags", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductTag.ProductId));
                b.Property(x => x.TagId).HasColumnName(nameof(ProductTag.TagId));

                b.HasKey(x => new { x.ProductId, x.TagId });
            });
            
            builder.Entity<ProductTemplateAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductTemplateAttributes", options.Schema);
                b.ConfigureCreationAudited();

                b.Property(x => x.ProductTemplateId).HasColumnName(nameof(ProductTemplateAttribute.ProductTemplateId));
                b.Property(x => x.AttributeId).HasColumnName(nameof(ProductTemplateAttribute.AttributeId));

                b.HasKey(x => new { x.ProductTemplateId, x.AttributeId });
            });
            
            builder.Entity<ProductVendor>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductVendors", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductVendor.ProductId));
                b.Property(x => x.VendorId).HasColumnName(nameof(ProductVendor.VendorId));

                b.HasKey(x => new { x.ProductId, x.VendorId });
            });
        }
    }
}