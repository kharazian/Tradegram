using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Aggregates;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes
{
    public static class SpecificationAttributesDbContextModelCreatingExtensions
    {
        public static void ConfigureSpecificationAttributes(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);


            builder.Entity<SpecificationAttribute>(b =>
            {
                b.ToTable(options.TablePrefix + "SpecificationAttributes", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(SpecificationAttribute.Name))
                    .HasMaxLength(SpecificationAttributeConsts.MaxNameLength);

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(SpecificationAttribute.DisplayOrder));

                b.HasMany<SpecificationAttributeOption>().WithOne().HasForeignKey(x => x.SpecificationAttributeId)
                    .IsRequired();
            });
            
            builder.Entity<SpecificationAttributeOption>(b =>
            {
                b.ToTable(options.TablePrefix + "SpecificationAttributeOptions", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.SpecificationAttributeId)
                    .HasColumnName(nameof(SpecificationAttributeOption.SpecificationAttributeId));
                
                b.Property(x => x.ColorSquaresRgb).HasMaxLength(SpecificationAttributeConsts.MaxColorSquaresRgbLength)
                    .HasColumnName(nameof(SpecificationAttributeOption.ColorSquaresRgb));

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(SpecificationAttributeOption.Name))
                    .HasMaxLength(SpecificationAttributeConsts.MaxNameLength);

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(SpecificationAttributeOption.DisplayOrder));
            });
        }
    }
}