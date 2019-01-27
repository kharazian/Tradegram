using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public static class AttributesDbContextModelCreatingExtensions
    {
        public static void ConfigureAttributes(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<ProductAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductAttributes", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ProductAttribute.Name))
                    .HasMaxLength(AttributeConsts.MaxNameLength);

                b.Property(x => x.Description).IsRequired().HasColumnName(nameof(ProductAttribute.Description))
                    .HasMaxLength(AttributeConsts.MaxDescriptionLength);
            });

            builder.Entity<PredefinedAttributeValue>(b =>
            {
                b.ToTable(options.TablePrefix + "PredefinedAttributeValues", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.ProductAttributeId).IsRequired()
                    .HasColumnName(nameof(PredefinedAttributeValue.ProductAttributeId));

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(PredefinedAttributeValue.Name))
                    .HasMaxLength(AttributeConsts.MaxNameLength);

                b.Property(x => x.PriceAdjustment).IsRequired()
                    .HasColumnName(nameof(PredefinedAttributeValue.PriceAdjustment));

                b.Property(x => x.PriceAdjustmentUsePercentage)
                    .HasColumnName(nameof(PredefinedAttributeValue.PriceAdjustmentUsePercentage));

                b.Property(x => x.WeightAdjustment).HasColumnName(nameof(PredefinedAttributeValue.WeightAdjustment));
                b.Property(x => x.Cost).HasColumnName(nameof(PredefinedAttributeValue.Cost));

                b.Property(x => x.IsPreSelected).HasColumnName(nameof(PredefinedAttributeValue.IsPreSelected))
                    .HasDefaultValue(false);

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(PredefinedAttributeValue.DisplayOrder));
            });
        }
    }
}