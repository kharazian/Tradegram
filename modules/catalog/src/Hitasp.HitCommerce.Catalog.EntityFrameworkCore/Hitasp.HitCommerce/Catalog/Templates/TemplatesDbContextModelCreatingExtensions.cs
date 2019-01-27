using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Templates
{
    public static class TemplatesDbContextModelCreatingExtensions
    {
        public static void ConfigureTemplates(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Template>(b =>
            {
                b.ToTable(options.TablePrefix + "ViewTemplates", options.Schema);
                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(Template.Name));
                b.Property(x => x.ViewPath).HasColumnName(nameof(Template.ViewPath));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(Template.DisplayOrder));
            });
        }
    }
}