using System;
using Hitasp.HitCommerce.Catalog.Brands.Aggregates;
using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

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

            
            builder.Entity<Brand>(b =>
            {
                b.ToTable(options.TablePrefix + "Brands", options.Schema);
                
                b.ConfigureAsContent();
                
                b.Property(x => x.BrandTemplateId).IsRequired().HasColumnName(nameof(Brand.BrandTemplateId));
                b.Property(x => x.PriceRanges).HasColumnName(nameof(Brand.PriceRanges));
                
                b.HasOne<BrandTemplate>().WithMany().HasForeignKey(x => x.BrandTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}