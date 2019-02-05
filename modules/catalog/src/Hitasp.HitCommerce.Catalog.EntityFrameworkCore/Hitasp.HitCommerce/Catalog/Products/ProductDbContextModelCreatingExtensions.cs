using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public static class ProductsDbContextModelCreatingExtensions
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

                b.HasDiscriminator<string>("ProductType")
                    .HasValue<Downloadable>(nameof(ProductType.Downloadable))
                    .HasValue<Shippable>(nameof(ProductType.Shippable))
                    .HasValue<Servicable>(nameof(ProductType.Service));

                b.HasIndex(x => x.ProductType);
                b.HasIndex(x => x.Code).IsUnique();

                b.ConfigureFullAudited();
                b.ConfigureExtraProperties();

                #region General

                b.Property(x => x.ProductType).IsRequired().HasMaxLength(20).HasColumnName(nameof(Product.ProductType));
                b.Property(x => x.ProductTemplateId).IsRequired().HasColumnName(nameof(Product.ProductTemplateId));

                b.HasOne<Template>().WithMany().IsRequired().HasForeignKey(x => x.ProductTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.Property(x => x.Name).IsRequired().HasMaxLength(ProductConsts.MaxNameLength)
                    .HasColumnName(nameof(Product.Name));

                b.Property(x => x.ShortDescription).IsRequired().HasMaxLength(ProductConsts.MaxShortDescriptionLength)
                    .HasColumnName(nameof(Product.ShortDescription));

                b.Property(x => x.FullDescription).HasMaxLength(ProductConsts.MaxDescriptionLength)
                    .HasColumnName(nameof(Product.FullDescription));

                b.Property(x => x.Code).IsRequired().HasMaxLength(ProductConsts.MaxCodeLength)
                    .HasColumnName(nameof(Product.Code));

                b.Property(x => x.Gtin).HasMaxLength(ProductConsts.MaxGtinLength)
                    .HasColumnName(nameof(Product.Gtin));

                b.Property(x => x.ManufacturerPartNumber).HasMaxLength(150)
                    .HasColumnName(nameof(Product.ManufacturerPartNumber));

                b.Property(x => x.ShowOnHomePage).HasColumnName(nameof(Product.ShowOnHomePage));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(Product.DisplayOrder));
                b.Property(x => x.RatingAverage).HasColumnName(nameof(Product.RatingAverage));
                b.Property(x => x.RatingCount).HasColumnName(nameof(Product.RatingCount));
                b.Property(x => x.AvailableStartDate).HasColumnName(nameof(Product.AvailableStartDate));
                b.Property(x => x.AvailableEndDate).HasColumnName(nameof(Product.AvailableEndDate));
                b.Property(x => x.MarkAsNew).HasColumnName(nameof(Product.MarkAsNew));
                b.Property(x => x.MarkAsNewStartDate).HasColumnName(nameof(Product.MarkAsNewStartDate));
                b.Property(x => x.MarkAsNewEndDate).HasColumnName(nameof(Product.MarkAsNewEndDate));
                b.Property(x => x.Published).HasColumnName(nameof(Product.Published));
                b.HasMany(x => x.ProductTags).WithOne().OnDelete(DeleteBehavior.Cascade);

                #endregion

                #region Pricing

                b.Property(x => x.BasePriceEnabled).HasColumnName(nameof(Product.BasePriceEnabled));

                b.OwnsOne(x => x.ProductBasePrice, pbp =>
                {
                    pbp.ToTable(options.TablePrefix + "Product_BasePrice", options.Schema);

                    pbp.Property(x => x.BasePriceAmount).HasColumnName(nameof(ProductBasePrice.BasePriceAmount));
                    pbp.Property(x => x.BasePriceUnitId).HasColumnName(nameof(ProductBasePrice.BasePriceUnitId));

                    pbp.Property(x => x.BasePriceBaseAmount)
                        .HasColumnName(nameof(ProductBasePrice.BasePriceBaseAmount));

                    pbp.Property(x => x.BasePriceBaseUnitId)
                        .HasColumnName(nameof(ProductBasePrice.BasePriceBaseUnitId));
                });

                b.OwnsOne(x => x.Pricing, pp =>
                {
                    pp.ToTable(options.TablePrefix + "Product_Pricing", options.Schema);
                    
                    pp.Property(x => x.Price).HasDefaultValue(decimal.Zero)
                        .HasColumnName(nameof(ProductPricing.Price));
                    
                    pp.Property(x => x.OldPrice).HasDefaultValue(decimal.Zero)
                        .HasColumnName(nameof(ProductPricing.OldPrice));

                    pp.Property(x => x.ProductCost).HasColumnName(nameof(ProductPricing.ProductCost));
                    pp.Property(x => x.DisableBuyButton).HasColumnName(nameof(ProductPricing.DisableBuyButton));
                    pp.Property(x => x.DisableWishListButton).HasColumnName(nameof(ProductPricing.DisableWishListButton));

                    pp.Property(x => x.CallForPrice).HasColumnName(nameof(ProductPricing.CallForPrice));
                    pp.Property(x => x.AvailableForPreOrder).HasColumnName(nameof(ProductPricing.AvailableForPreOrder));

                    pp.Property(x => x.PreOrderAvailabilityStartDate)
                        .HasColumnName(nameof(ProductPricing.PreOrderAvailabilityStartDate));
                    
                    pp.Property(x => x.CustomerEntersPrice)
                        .HasColumnName(nameof(ProductPricing.CustomerEntersPrice));

                    pp.Property(x => x.MinimumCustomerEnteredPrice)
                        .HasColumnName(nameof(ProductPricing.MinimumCustomerEnteredPrice));

                    pp.Property(x => x.MaximumCustomerEnteredPrice)
                        .HasColumnName(nameof(ProductPricing.MaximumCustomerEnteredPrice));

                    pp.Property(x => x.IsRental).HasColumnName(nameof(ProductPricing.IsRental));
                    pp.Property(x => x.RentalPriceLength).HasColumnName(nameof(ProductPricing.RentalPriceLength));
                    pp.Property(x => x.RentalPricePeriodId).HasColumnName(nameof(ProductPricing.RentalPricePeriodId));
                    pp.Ignore(x => x.RentalPricePeriod);
                    
                    pp.Property(x => x.IsRecurring).HasColumnName(nameof(ProductPricing.IsRecurring));
                    pp.Property(x => x.RecurringCycleLength).HasColumnName(nameof(ProductPricing.RecurringCycleLength));
                    pp.Property(x => x.RecurringTotalCycles).HasColumnName(nameof(ProductPricing.RecurringTotalCycles));
                    pp.Property(x => x.RecurringCyclePeriodId).HasColumnName(nameof(ProductPricing.RecurringCyclePeriodId));
                    pp.Ignore(x => x.RecurringCyclePeriod);
                 
                    pp.Property(x => x.IsTaxExempt).HasDefaultValue(true)
                        .HasColumnName(nameof(ProductPricing.IsTaxExempt));

                    pp.Property(x => x.TaxCategoryId).IsRequired(false)
                        .HasColumnName(nameof(ProductPricing.TaxCategoryId));
                });

                #endregion

                #region Products Link

                b.HasMany(x => x.RequiredProducts).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.RelatedProducts).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.CrossSellProducts).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                #endregion

                #region Mapping

                b.HasMany(x => x.ProductCategories).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.ProductManufacturers).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.Property(x => x.VendorId).HasColumnName(nameof(Product.VendorId));

                #endregion

                #region Related Data

                b.Property(x => x.MetaTitle).HasMaxLength(ProductConsts.MaxMetaTitleLength)
                    .HasColumnName(nameof(Product.MetaTitle));

                b.Property(x => x.MetaKeywords).HasMaxLength(ProductConsts.MaxMetaKeywordsLength)
                    .HasColumnName(nameof(Product.MetaKeywords));

                b.Property(x => x.MetaDescription)
                    .HasMaxLength(ProductConsts.MaxMetaDescriptionLength)
                    .HasColumnName(nameof(Product.MetaDescription));

                b.HasMany(x => x.ProductPictures).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.ProductProductAttributes).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.ProductSpecificationAttributes).WithOne().HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                #endregion
            });

            builder.Entity<Downloadable>(b =>
            {
                b.Property(x => x.DownloadId).HasColumnName(nameof(Downloadable.DownloadId));
                b.Property(x => x.UnlimitedDownloads).HasColumnName(nameof(Downloadable.UnlimitedDownloads));
                b.Property(x => x.MaxNumberOfDownloads).HasColumnName(nameof(Downloadable.MaxNumberOfDownloads));
                b.Property(x => x.DownloadExpirationDays).HasColumnName(nameof(Downloadable.DownloadExpirationDays));
                b.Property(x => x.HasSampleDownload).HasColumnName(nameof(Downloadable.HasSampleDownload));
                b.Property(x => x.SampleDownloadId).HasColumnName(nameof(Downloadable.SampleDownloadId));

                b.Property(x => x.DownloadActivationTypeId)
                    .HasColumnName(nameof(Downloadable.DownloadActivationTypeId));

                b.Ignore(x => x.DownloadActivationType);

                b.Property(x => x.IsGiftCard).HasColumnName(nameof(Downloadable.IsGiftCard));

                b.Property(x => x.GiftCardTypeId).HasColumnName(nameof(Downloadable.GiftCardTypeId));

                b.Property(x => x.HasUserAgreement).HasColumnName(nameof(Downloadable.HasUserAgreement));
                b.Property(x => x.UserAgreementText).HasColumnName(nameof(Downloadable.UserAgreementText));

                b.Property(x => x.BasePriceEnabled).HasDefaultValue(false);
            });

            builder.Entity<Shippable>(b =>
            {
                b.Property(x => x.IsGiftCard).HasColumnName(nameof(Shippable.IsGiftCard));

                b.Property(x => x.GiftCardTypeId).HasColumnName(nameof(Shippable.GiftCardTypeId));

                b.Property(x => x.OverriddenGiftCardAmount)
                    .HasColumnName(nameof(Shippable.OverriddenGiftCardAmount));

                b.Ignore(x => x.GiftCardType);

                b.OwnsOne(x => x.Inventory, pi =>
                {
                    pi.ToTable(options.TablePrefix + "Product_Inventory", options.Schema);

                    pi.Property(x => x.StockQuantity).IsRequired().HasColumnName(nameof(ProductInventory.StockQuantity));
                    pi.Property(x => x.WarehouseId).HasColumnName(nameof(ProductInventory.WarehouseId));
                    pi.Property(x => x.UseMultipleWarehouses)
                        .HasColumnName(nameof(ProductInventory.UseMultipleWarehouses));
                    
                    pi.Property(x => x.DisplayStockAvailability)
                        .HasColumnName(nameof(ProductInventory.DisplayStockAvailability));

                    pi.Property(x => x.DisplayStockQuantity)
                        .HasColumnName(nameof(ProductInventory.DisplayStockQuantity));

                    pi.Property(x => x.MinStockQuantity).HasColumnName(nameof(ProductInventory.MinStockQuantity));

                    pi.Property(x => x.AllowBackInStockSubscriptions)
                        .HasColumnName(nameof(ProductInventory.AllowBackInStockSubscriptions));

                    pi.Property(x => x.MinStockQuantity).HasColumnName(nameof(ProductInventory.MinStockQuantity));

                    pi.Property(x => x.OrderMinimumQuantity).HasColumnName(nameof(ProductInventory.OrderMinimumQuantity));
                    pi.Property(x => x.OrderMaximumQuantity).HasColumnName(nameof(ProductInventory.OrderMaximumQuantity));
                    pi.Property(x => x.AllowedQuantities).HasColumnName(nameof(ProductInventory.AllowedQuantities));

                    pi.Property(x => x.NotReturnable)
                        .HasColumnName(nameof(ProductInventory.NotReturnable));
                });

                b.Property(x => x.IsShipEnabled).HasColumnName(nameof(Shippable.IsShipEnabled));
                b.OwnsOne(x => x.Shipping, ps =>
                {
                    ps.ToTable(options.TablePrefix + "Product_Shipping", options.Schema);

                    ps.Property(x => x.IsFreeShipping).HasColumnName(nameof(ProductShipping.IsFreeShipping));
                    ps.Property(x => x.AdditionalShippingCharge)
                        .HasColumnName(nameof(ProductShipping.AdditionalShippingCharge));
                    ps.Property(x => x.ShipSeparately).HasColumnName(nameof(ProductShipping.ShipSeparately));

                    ps.Property(x => x.DeliveryDateId).HasColumnName(nameof(ProductShipping.DeliveryDateId));
                    ps.Property(x => x.Weight).HasColumnName(nameof(ProductShipping.Weight));
                    ps.Property(x => x.Length).HasColumnName(nameof(ProductShipping.Length));
                    ps.Property(x => x.Width).HasColumnName(nameof(ProductShipping.Width));
                    ps.Property(x => x.Height).HasColumnName(nameof(ProductShipping.Height));
                });
                
                b.HasMany(x => x.ProductWarehouseInventories).WithOne()
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.ProductAttributeCombinations).WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Servicable>(b => { b.Property(x => x.BasePriceEnabled).HasDefaultValue(false); });
       
            builder.Entity<ProductAttributeCombination>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_AttributeCombinations", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductAttributeCombination.ProductId));
                b.Property(x => x.PictureId).HasColumnName(nameof(ProductAttributeCombination.PictureId));

                b.Property(x => x.ManufacturerPartNumber)
                    .HasColumnName(nameof(ProductAttributeCombination.ManufacturerPartNumber));

                b.Property(x => x.Code).HasColumnName(nameof(ProductAttributeCombination.Code));

                b.Property(x => x.StockQuantity).HasColumnName(nameof(ProductAttributeCombination.StockQuantity));

                b.Property(x => x.AllowOutOfStockOrders)
                    .HasColumnName(nameof(ProductAttributeCombination.AllowOutOfStockOrders));

                b.Property(x => x.Gtin).HasColumnName(nameof(ProductAttributeCombination.Gtin));
                b.Property(x => x.OverriddenPrice).HasColumnName(nameof(ProductAttributeCombination.OverriddenPrice));

                b.Property(x => x.AttributesXml).HasColumnName(nameof(ProductAttributeCombination.AttributesXml));
            });

            builder.Entity<ProductAttributeValue>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_AttributeValues", options.Schema);

                b.HasKey(x => new {x.ProductId, x.ProductAttributeId});

                b.Property(x => x.PictureId).HasColumnName(nameof(ProductAttributeValue.PictureId));
                b.Property(x => x.Name).HasColumnName(nameof(ProductAttributeValue.Name)).IsRequired();
                b.Property(x => x.ColorSquaresRgb).HasColumnName(nameof(ProductAttributeValue.ColorSquaresRgb));

                b.Property(x => x.ImageSquaresPictureId)
                    .HasColumnName(nameof(ProductAttributeValue.ImageSquaresPictureId));

                b.Property(x => x.PriceAdjustment).HasColumnName(nameof(ProductAttributeValue.PriceAdjustment));

                b.Property(x => x.PriceAdjustmentUsePercentage)
                    .HasColumnName(nameof(ProductAttributeValue.PriceAdjustmentUsePercentage));

                b.Property(x => x.WeightAdjustment).HasColumnName(nameof(ProductAttributeValue.WeightAdjustment));
                b.Property(x => x.Cost).HasColumnName(nameof(ProductAttributeValue.Cost));
                b.Property(x => x.CustomerEntersQty).HasColumnName(nameof(ProductAttributeValue.CustomerEntersQty));
                b.Property(x => x.Quantity).HasColumnName(nameof(ProductAttributeValue.Quantity));
                b.Property(x => x.IsPreSelected).HasColumnName(nameof(ProductAttributeValue.IsPreSelected));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductAttributeValue.DisplayOrder));
                b.Property(x => x.AttributeValueType).HasColumnName(nameof(ProductAttributeValue.AttributeValueType));

                b.HasOne<ProductProductAttribute>().WithMany(x => x.ProductAttributeValues).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ProductProductAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_Attributes", options.Schema);
                b.HasKey(x => new {x.ProductId, x.ProductAttributeId});

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductProductAttribute.ProductId));
                b.Property(x => x.ProductAttributeId).HasColumnName(nameof(ProductProductAttribute.ProductAttributeId));
                b.Property(x => x.TextPrompt).HasColumnName(nameof(ProductProductAttribute.TextPrompt));
                b.Property(x => x.IsRequired).HasColumnName(nameof(ProductProductAttribute.IsRequired));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductProductAttribute.DisplayOrder));

                b.Property(x => x.ValidationMinLength)
                    .HasColumnName(nameof(ProductProductAttribute.ValidationMinLength));

                b.Property(x => x.ValidationMaxLength)
                    .HasColumnName(nameof(ProductProductAttribute.ValidationMaxLength));

                b.Property(x => x.ValidationFileAllowedExtensions)
                    .HasColumnName(nameof(ProductProductAttribute.ValidationFileAllowedExtensions));

                b.Property(x => x.ValidationFileMaximumSize)
                    .HasColumnName(nameof(ProductProductAttribute.ValidationFileMaximumSize));

                b.Property(x => x.DefaultValue).HasColumnName(nameof(ProductProductAttribute.DefaultValue));

                b.Property(x => x.ConditionAttributeXml)
                    .HasColumnName(nameof(ProductProductAttribute.ConditionAttributeXml));

                b.Property(x => x.AttributeControlType)
                    .HasColumnName(nameof(ProductProductAttribute.AttributeControlType));

                b.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ProductAttribute>().WithMany().HasForeignKey(x => x.ProductAttributeId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<StockQuantityHistory>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_StockQuantityHistories", options.Schema);

                b.HasKey(x => x.Id);

                b.HasIndex(x => x.ProductId);

                b.Property(x => x.ProductId).HasColumnName(nameof(StockQuantityHistory.ProductId));
                b.Property(x => x.QuantityAdjustment).HasColumnName(nameof(StockQuantityHistory.QuantityAdjustment));
                b.Property(x => x.StockQuantity).HasColumnName(nameof(StockQuantityHistory.StockQuantity));
                b.Property(x => x.Message).HasColumnName(nameof(StockQuantityHistory.Message));
                b.Property(x => x.CombinationId).HasColumnName(nameof(StockQuantityHistory.CombinationId));
                b.Property(x => x.WarehouseId).HasColumnName(nameof(StockQuantityHistory.WarehouseId));
            });

            builder.Entity<CrossSellProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_CrossSellProduct", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(CrossSellProduct.ProductId));
                b.Property(x => x.CrossSellProductId).HasColumnName(nameof(CrossSellProduct.CrossSellProductId));

                b.HasKey(x => new {x.ProductId, x.CrossSellProductId});
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

            builder.Entity<ProductDiscount>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductDiscount", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductDiscount.ProductId));
                b.Property(x => x.DiscountId).HasColumnName(nameof(ProductDiscount.DiscountId));

                b.HasKey(x => new {x.ProductId, x.DiscountId});
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
                b.Property(x => x.PictureId).HasColumnName(nameof(ProductPicture.PictureId));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ProductPicture.DisplayOrder));

                b.HasKey(x => new {x.ProductId, x.PictureId});
            });

            builder.Entity<ProductProductTag>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductTag", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductProductTag.ProductId));
                b.Property(x => x.ProductTagId).HasColumnName(nameof(ProductProductTag.ProductTagId));

                b.HasKey(x => new {x.ProductId, TagId = x.ProductTagId});
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

            builder.Entity<ProductWarehouseInventory>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_ProductWarehouseInventory", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(ProductWarehouseInventory.ProductId));
                b.Property(x => x.WarehouseId).HasColumnName(nameof(ProductWarehouseInventory.WarehouseId));
                b.Property(x => x.StockQuantity).HasColumnName(nameof(ProductWarehouseInventory.StockQuantity));
                b.Property(x => x.ReservedQuantity).HasColumnName(nameof(ProductWarehouseInventory.ReservedQuantity));

                b.HasKey(x => new {x.ProductId, TagId = x.WarehouseId});
            });

            builder.Entity<RelatedProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_RelatedProduct", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(RelatedProduct.ProductId));
                b.Property(x => x.RelatedProductId).HasColumnName(nameof(RelatedProduct.RelatedProductId));

                b.HasKey(x => new {x.ProductId, x.RelatedProductId});
            });
            
            builder.Entity<RequiredProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "Products_RequiredProduct", options.Schema);

                b.Property(x => x.ProductId).HasColumnName(nameof(RequiredProduct.ProductId));
                b.Property(x => x.RequiredProductId).HasColumnName(nameof(RequiredProduct.RequiredProductId));

                b.HasKey(x => new {x.ProductId, x.RequiredProductId});
            });
        }
    }
}