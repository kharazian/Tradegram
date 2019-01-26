using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public static class TagDbContextModelCreatingExtensions
    {
        public static void ConfigureTagging(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Tag>(b =>
            {
                b.ToTable(options.TablePrefix + "Tags", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.SpaceId).IsRequired(false).HasColumnName(nameof(Tag.SpaceId));
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(Tag.Name));
                b.Property(x => x.Description).HasColumnName(nameof(Tag.Description));
                b.Property(x => x.UsageCount).HasDefaultValue(0).HasColumnName(nameof(Tag.UsageCount));
            });
        }
    }
}