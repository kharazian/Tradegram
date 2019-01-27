using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public static class TaggingDbContextModelCreatingExtensions
    {
        public static void ConfigureTagging(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<ProductTag>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductTags", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ProductTag.Name));
                b.Property(x => x.Description).HasColumnName(nameof(ProductTag.Description));
                b.Property(x => x.UsageCount).HasDefaultValue(0).HasColumnName(nameof(ProductTag.UsageCount));
            });
        }
    }
}