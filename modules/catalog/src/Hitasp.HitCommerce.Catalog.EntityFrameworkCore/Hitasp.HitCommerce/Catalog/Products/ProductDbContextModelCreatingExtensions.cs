using System;
using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Templates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public static class ProductDbContextModelCreatingExtensions
    {
        public static void ConfigureProducts(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Product>(b =>
            {
                b.ToTable(options.TablePrefix + "Products", options.Schema);

                b.HasKey(x => x.Id);

                b.HasDiscriminator<string>(nameof(Product.ProductType))
                    .HasValue<VirtualProduct>(nameof(VirtualProduct))
                    .HasValue<PhysicalProduct>(nameof(PhysicalProduct));

                b.HasIndex(x => x.SpaceId);
                b.HasIndex(x => x.ProductType);
                b.ConfigureFullAudited();

                b.Property(x => x.ProductType).IsRequired().HasMaxLength(10).HasColumnName(nameof(Product.ProductType));
                b.Property(x => x.SpaceId).IsRequired(false).HasColumnName(nameof(Product.SpaceId));
                b.Property(x => x.ProductTemplateId).IsRequired().HasColumnName(nameof(Product.ProductTemplateId));
                b.Property(x => x.ProductCodeId).IsRequired().HasColumnName(nameof(Product.ProductCodeId));
                b.Property(x => x.ProductInfoId).IsRequired().HasColumnName(nameof(Product.ProductInfoId));
                b.Property(x => x.ProductMetaId).IsRequired().HasColumnName(nameof(Product.ProductMetaId));
                b.Property(x => x.ProductPriceInfoId).IsRequired().HasColumnName(nameof(Product.ProductPriceInfoId));

                b.Property(x => x.ProductPublishingInfoId).IsRequired()
                    .HasColumnName(nameof(Product.ProductPublishingInfoId));

                b.Property(x => x.ProductOrderingInfoId).IsRequired()
                    .HasColumnName(nameof(Product.ProductOrderingInfoId));

                b.Property(x => x.ProductRateId).IsRequired().HasColumnName(nameof(Product.ProductRateId));

                b.Property(x => x.ProductShippingInfoId).IsRequired()
                    .HasColumnName(nameof(Product.ProductShippingInfoId));


                b.HasOne<ProductCode>().WithOne().IsRequired().HasForeignKey<ProductCode>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductInfo>().WithOne().IsRequired().HasForeignKey<ProductInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductMeta>().WithOne().IsRequired().HasForeignKey<ProductMeta>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductPriceInfo>().WithOne().IsRequired().HasForeignKey<ProductPriceInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductPublishingInfo>().WithOne().IsRequired().HasForeignKey<ProductPublishingInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductOrderingInfo>().WithOne().IsRequired().HasForeignKey<ProductOrderingInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductRate>().WithOne().IsRequired().HasForeignKey<ProductRate>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductShippingInfo>().WithOne().IsRequired().HasForeignKey<ProductShippingInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Template>().WithMany().IsRequired().HasForeignKey(x => x.ProductTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany<ProductCategory>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductManufacturer>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductPicture>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductSpecificationAttribute>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductTag>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductAttribute>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductDiscount>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductAttributeCombination>().WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ProductCode>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_Code", options.Schema);

                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Code).IsUnique();

                b.Property(x => x.Code).IsRequired().HasMaxLength(ProductConsts.MaxCodeLength)
                    .HasColumnName(nameof(ProductCode.Code));
            });

            builder.Entity<ProductInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_Info", options.Schema);

                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Name);
                b.HasIndex(x => x.Title);

                b.Property(x => x.Name).IsRequired().HasMaxLength(ProductConsts.MaxNameLength)
                    .HasColumnName(nameof(ProductInfo.Name));

                b.Property(x => x.Title).IsRequired().HasMaxLength(ProductConsts.MaxTitleLength)
                    .HasColumnName(nameof(ProductInfo.Title));

                b.Property(x => x.Title).IsRequired().HasMaxLength(ProductConsts.MaxShortDescriptionLength)
                    .HasColumnName(nameof(ProductInfo.ShortDescription));

                b.Property(x => x.Description).HasMaxLength(ProductConsts.MaxDescriptionLength)
                    .HasColumnName(nameof(ProductInfo.Description));

                b.Property(x => x.DisplayOrder).HasDefaultValue(0).HasColumnName(nameof(ProductInfo.DisplayOrder));
            });

            builder.Entity<ProductMeta>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_Meta", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.MetaTitle).IsRequired(false).HasMaxLength(ProductConsts.MaxMetaTitleLength)
                    .HasColumnName(nameof(ProductMeta.MetaTitle));

                b.Property(x => x.MetaKeywords).IsRequired(false).HasMaxLength(ProductConsts.MaxMetaKeywordsLength)
                    .HasColumnName(nameof(ProductMeta.MetaKeywords));

                b.Property(x => x.MetaDescription).IsRequired(false)
                    .HasMaxLength(ProductConsts.MaxMetaDescriptionLength)
                    .HasColumnName(nameof(ProductMeta.MetaDescription));
            });

            builder.Entity<ProductPriceInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_PriceInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.Price).IsRequired().HasColumnName(nameof(ProductPriceInfo.Price));

                b.Property(x => x.OldPrice).HasDefaultValue(decimal.Zero)
                    .HasColumnName(nameof(ProductPriceInfo.OldPrice));

                b.Property(x => x.ProductCost).HasColumnName(nameof(ProductPriceInfo.ProductCost));
                b.Property(x => x.CallForPrice).HasColumnName(nameof(ProductPriceInfo.CallForPrice));

                b.Property(x => x.IsAllowCustomerEntersPrice)
                    .HasColumnName(nameof(ProductPriceInfo.IsAllowCustomerEntersPrice));

                b.Property(x => x.MinimumCustomerEnteredPrice)
                    .HasColumnName(nameof(ProductPriceInfo.MinimumCustomerEnteredPrice));

                b.Property(x => x.MaximumCustomerEnteredPrice)
                    .HasColumnName(nameof(ProductPriceInfo.MaximumCustomerEnteredPrice));

                b.Property(x => x.BasePriceEnabled).HasColumnName(nameof(ProductPriceInfo.BasePriceEnabled));
                b.Property(x => x.BasePriceAmount).HasColumnName(nameof(ProductPriceInfo.BasePriceAmount));
                b.Property(x => x.BasePriceUnitId).HasColumnName(nameof(ProductPriceInfo.BasePriceUnitId));
                b.Property(x => x.BasePriceBaseAmount).HasColumnName(nameof(ProductPriceInfo.BasePriceBaseAmount));
                b.Property(x => x.BasePriceBaseUnitId).HasColumnName(nameof(ProductPriceInfo.BasePriceBaseUnitId));

                b.Property(x => x.IsTaxExempt).HasDefaultValue(true)
                    .HasColumnName(nameof(ProductPriceInfo.IsTaxExempt));

                b.Property(x => x.TaxCategoryId).IsRequired(false)
                    .HasColumnName(nameof(ProductPriceInfo.TaxCategoryId));
            });

            builder.Entity<ProductPublishingInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_PublishingInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.VisibleIndividually).HasDefaultValue(true)
                    .HasColumnName(nameof(ProductPublishingInfo.VisibleIndividually));

                b.Property(x => x.IsNew).HasDefaultValue(false).HasColumnName(nameof(ProductPublishingInfo.IsNew));

                b.Property(x => x.IsPublished).HasDefaultValue(true)
                    .HasColumnName(nameof(ProductPublishingInfo.IsPublished));

                b.Property(x => x.MarkAsNewStartDate).HasColumnName(nameof(ProductPublishingInfo.MarkAsNewStartDate));
                b.Property(x => x.MarkAsNewEndDate).HasColumnName(nameof(ProductPublishingInfo.MarkAsNewEndDate));
                b.Property(x => x.AvailableStartDate).HasColumnName(nameof(ProductPublishingInfo.AvailableStartDate));
                b.Property(x => x.AvailableEndDate).HasColumnName(nameof(ProductPublishingInfo.AvailableEndDate));

                b.Property(x => x.ShowOnHomePage).HasDefaultValue(false)
                    .HasColumnName(nameof(ProductPublishingInfo.ShowOnHomePage));
            });

            builder.Entity<ProductOrderingInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_OrderingInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.AllowedQuantities).HasColumnName(nameof(ProductOrderingInfo.AllowedQuantities));
                b.Property(x => x.OrderMinimumQuantity).HasColumnName(nameof(ProductOrderingInfo.OrderMinimumQuantity));
                b.Property(x => x.OrderMaximumQuantity).HasColumnName(nameof(ProductOrderingInfo.OrderMaximumQuantity));
                b.Property(x => x.AvailableForPreOrder).HasColumnName(nameof(ProductOrderingInfo.AvailableForPreOrder));

                b.Property(x => x.PreOrderAvailabilityStartDate)
                    .HasColumnName(nameof(ProductOrderingInfo.PreOrderAvailabilityStartDate));

                b.Property(x => x.IsBuyButtonDisabled)
                    .HasColumnName(nameof(ProductOrderingInfo.IsBuyButtonDisabled));

                b.Property(x => x.IsWishListButtonDisabled)
                    .HasColumnName(nameof(ProductOrderingInfo.IsWishListButtonDisabled));

                b.Property(x => x.NotReturnable).HasColumnName(nameof(ProductOrderingInfo.NotReturnable));
                b.Property(x => x.IsRecurring).HasColumnName(nameof(ProductOrderingInfo.IsRecurring));
                b.Property(x => x.RecurringCycleLength).HasColumnName(nameof(ProductOrderingInfo.RecurringCycleLength));
                b.Property(x => x.RecurringCyclePeriod).HasColumnName(nameof(ProductOrderingInfo.RecurringCyclePeriod));
                b.Property(x => x.RecurringTotalCycles).HasColumnName(nameof(ProductOrderingInfo.RecurringTotalCycles));
                b.Property(x => x.IsRental).HasColumnName(nameof(ProductOrderingInfo.IsRental));
                b.Property(x => x.RentalPriceLength).HasColumnName(nameof(ProductOrderingInfo.RentalPriceLength));
                b.Property(x => x.RentalPricePeriod).HasColumnName(nameof(ProductOrderingInfo.RentalPricePeriod));
            });

            builder.Entity<ProductRate>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_Rate", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.RatingAverage).HasColumnName(nameof(ProductRate.RatingAverage));
                b.Property(x => x.RatingCount).HasColumnName(nameof(ProductRate.RatingCount));
            });

            builder.Entity<ProductShippingInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ShippingInfo", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.IsShipEnabled).HasColumnName(nameof(ProductShippingInfo.IsShipEnabled));
                b.Property(x => x.IsFreeShipping).HasColumnName(nameof(ProductShippingInfo.IsFreeShipping));
                b.Property(x => x.ShipSeparately).HasColumnName(nameof(ProductShippingInfo.ShipSeparately));

                b.Property(x => x.AdditionalShippingCharge)
                    .HasColumnName(nameof(ProductShippingInfo.AdditionalShippingCharge));

                b.Property(x => x.DeliveryDateId).HasColumnName(nameof(ProductShippingInfo.DeliveryDateId));
                b.Property(x => x.Weight).HasColumnName(nameof(ProductShippingInfo.Weight));
                b.Property(x => x.Length).HasColumnName(nameof(ProductShippingInfo.Length));
                b.Property(x => x.Width).HasColumnName(nameof(ProductShippingInfo.Width));
                b.Property(x => x.Height).HasColumnName(nameof(ProductShippingInfo.Height));

                b.Property(x => x.UseMultipleWarehouses)
                    .HasColumnName(nameof(ProductShippingInfo.UseMultipleWarehouses));

                b.Property(x => x.WarehouseId).HasColumnName(nameof(ProductShippingInfo.WarehouseId));

                b.Property(x => x.ProductAvailabilityRangeId)
                    .HasColumnName(nameof(ProductShippingInfo.ProductAvailabilityRangeId));
            });

            builder.Entity<ProductAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_Attributes", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductAttribute.ProductId));
                b.Property(x => x.CatalogAttributeId).HasColumnName(nameof(ProductAttribute.CatalogAttributeId));
                b.Property(x => x.TextPrompt).HasColumnName(nameof(ProductAttribute.TextPrompt));
                b.Property(x => x.IsRequired).HasColumnName(nameof(ProductAttribute.IsRequired));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductAttribute.DisplayOrder));
                b.Property(x => x.ValidationMinLength).HasColumnName(nameof(ProductAttribute.ValidationMinLength));
                b.Property(x => x.ValidationMaxLength).HasColumnName(nameof(ProductAttribute.ValidationMaxLength));

                b.Property(x => x.ValidationFileAllowedExtensions)
                    .HasColumnName(nameof(ProductAttribute.ValidationFileAllowedExtensions));

                b.Property(x => x.ValidationFileMaximumSize)
                    .HasColumnName(nameof(ProductAttribute.ValidationFileMaximumSize));

                b.Property(x => x.DefaultValue).HasColumnName(nameof(ProductAttribute.DefaultValue));
                b.Property(x => x.ConditionAttributeXml).HasColumnName(nameof(ProductAttribute.ConditionAttributeXml));
                b.Property(x => x.AttributeControlType).HasColumnName(nameof(ProductAttribute.AttributeControlType));

                b.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<CatalogAttribute>().WithMany().HasForeignKey(x => x.CatalogAttributeId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany<ProductAttributeValue>().WithOne().HasForeignKey(x => x.ProductAttributeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ProductAttributeCombination>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_AttributeCombinations", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductAttributeCombination.ProductId));
                b.Property(x => x.PictureId).HasColumnName(nameof(ProductAttributeCombination.PictureId));
                b.Property(x => x.StockQuantity).HasColumnName(nameof(ProductAttributeCombination.StockQuantity));

                b.Property(x => x.AllowOutOfStockOrders)
                    .HasColumnName(nameof(ProductAttributeCombination.AllowOutOfStockOrders));

                b.Property(x => x.Gtin).HasColumnName(nameof(ProductAttributeCombination.Gtin));
                b.Property(x => x.OverriddenPrice).HasColumnName(nameof(ProductAttributeCombination.OverriddenPrice));

                b.Property(x => x.NotifyAdminForQuantityBelow)
                    .HasColumnName(nameof(ProductAttributeCombination.NotifyAdminForQuantityBelow));

                b.Property(x => x.AttributesXml).HasColumnName(nameof(ProductAttributeCombination.AttributesXml));

                b.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ProductCategory>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductCategory", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductCategory.ProductId));
                b.Property(x => x.CategoryId).HasColumnName(nameof(ProductCategory.CategoryId));
                b.Property(x => x.IsFeaturedProduct).HasColumnName(nameof(ProductCategory.IsFeaturedProduct));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductCategory.DisplayOrder));

                b.HasKey(x => new {x.ProductId, x.CategoryId});
            });

            builder.Entity<ProductManufacturer>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductManufacturer", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductManufacturer.ProductId));
                b.Property(x => x.ManufacturerId).HasColumnName(nameof(ProductManufacturer.ManufacturerId));
                b.Property(x => x.IsFeaturedProduct).HasColumnName(nameof(ProductManufacturer.IsFeaturedProduct));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductManufacturer.DisplayOrder));

                b.HasKey(x => new {x.ProductId, x.ManufacturerId});
            });

            builder.Entity<ProductPicture>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductPicture", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductPicture.ProductId));
                b.Property(x => x.PictureId).HasColumnName(nameof(ProductPicture.ProductId));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductPicture.DisplayOrder));

                b.HasKey(x => new {x.ProductId, x.PictureId});
            });

            builder.Entity<ProductSpecificationAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductSpecificationAttribute", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductSpecificationAttribute.ProductId));

                b.Property(x => x.SpecificationAttributeOptionId)
                    .HasColumnName(nameof(ProductSpecificationAttribute.SpecificationAttributeOptionId));

                b.Property(x => x.CustomValue).HasColumnName(nameof(ProductSpecificationAttribute.CustomValue));
                b.Property(x => x.AllowFiltering).HasColumnName(nameof(ProductSpecificationAttribute.AllowFiltering));

                b.Property(x => x.ShowOnProductPage)
                    .HasColumnName(nameof(ProductSpecificationAttribute.ShowOnProductPage));

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductSpecificationAttribute.DisplayOrder));
                b.Property(x => x.AttributeType).HasColumnName(nameof(ProductSpecificationAttribute.AttributeType));

                b.HasKey(x => new {x.ProductId, x.SpecificationAttributeOptionId});
            });

            builder.Entity<ProductTag>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductTag", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductTag.ProductId));
                b.Property(x => x.TagId).HasColumnName(nameof(ProductTag.TagId));

                b.HasKey(x => new {x.ProductId, x.TagId});
            });

            builder.Entity<ProductDiscount>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductDiscount", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductDiscount.ProductId));
                b.Property(x => x.DiscountId).HasColumnName(nameof(ProductDiscount.DiscountId));

                b.HasKey(x => new {x.ProductId, x.DiscountId});
            });
            
            builder.Entity<CrossSellProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_CrossSellProduct", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(CrossSellProduct.ProductId));
                b.Property(x => x.CrossSellProductId).HasColumnName(nameof(CrossSellProduct.CrossSellProductId));

                b.HasKey(x => new {x.ProductId, x.CrossSellProductId});
            });
            
            builder.Entity<RelatedProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_RelatedProduct", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(RelatedProduct.ProductId));
                b.Property(x => x.RelatedProductId).HasColumnName(nameof(RelatedProduct.RelatedProductId));

                b.HasKey(x => new {x.ProductId, x.RelatedProductId});
            });
            
            builder.Entity<BackInStockSubscription>(b =>
            {
                b.ToTable(options.TablePrefix + "BackInStockSubscriptions", options.Schema);

                b.ConfigureCreationAudited();
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.ProductId);
                
                b.Property(x => x.ProductId).HasColumnName(nameof(BackInStockSubscription.ProductId));
                b.Property(x => x.CustomerId).HasColumnName(nameof(BackInStockSubscription.CustomerId));
                b.Property(x => x.SpaceId).HasColumnName(nameof(BackInStockSubscription.SpaceId));
            });
        }
    }
}