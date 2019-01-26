using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public static class AttributeDbContextModelCreatingExtensions
    {
        public static void ConfigureAttributes(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<CatalogAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "CatalogAttributes", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(CatalogAttribute.Name))
                    .HasMaxLength(AttributeConsts.MaxNameLength);

                b.Property(x => x.Description).IsRequired().HasColumnName(nameof(CatalogAttribute.Description))
                    .HasMaxLength(AttributeConsts.MaxDescriptionLength);

                b.Property(x => x.SpaceId).HasColumnName(nameof(CatalogAttribute.SpaceId));
            });

            builder.Entity<PredefinedAttributeValue>(b =>
            {
                b.ToTable(options.TablePrefix + "PredefinedAttributeValues", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.CatalogAttributeId).IsRequired()
                    .HasColumnName(nameof(PredefinedAttributeValue.CatalogAttributeId));

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

            builder.Entity<SpecificationAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "SpecificationAttributes", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(SpecificationAttribute.Name))
                    .HasMaxLength(AttributeConsts.MaxNameLength);

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(SpecificationAttribute.DisplayOrder));
                b.Property(x => x.SpaceId).HasColumnName(nameof(SpecificationAttribute.SpaceId));

                b.HasMany<SpecificationAttributeOption>().WithOne().HasForeignKey(x => x.SpecificationAttributeId)
                    .IsRequired();
            });
            
            builder.Entity<SpecificationAttributeOption>(b =>
            {
                b.ToTable(options.TablePrefix + "SpecificationAttributeOptions", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.SpecificationAttributeId)
                    .HasColumnName(nameof(SpecificationAttributeOption.SpecificationAttributeId));
                
                b.Property(x => x.ColorSquaresRgb).HasMaxLength(AttributeConsts.MaxColorSquaresRgbLength)
                    .HasColumnName(nameof(SpecificationAttributeOption.ColorSquaresRgb));

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(SpecificationAttributeOption.Name))
                    .HasMaxLength(AttributeConsts.MaxNameLength);

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(SpecificationAttributeOption.DisplayOrder));
            });
        }
    }
}