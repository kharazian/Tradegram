using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public static class ManufacturersDbContextModelCreatingExtensions
    {
        public static void ConfigureManufacturers(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Manufacturer>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers", options.Schema);

                b.HasKey(x => x.Id);

                b.ConfigureFullAudited();
                b.ConfigureExtraProperties();

                b.Property(x => x.ManufacturerTemplateId).IsRequired()
                    .HasColumnName(nameof(Manufacturer.ManufacturerTemplateId));

                b.Property(x => x.PictureId).HasColumnName(nameof(Manufacturer.PictureId));

                b.Property(x => x.Name).IsRequired().HasMaxLength(ManufacturerConsts.MaxNameLength)
                    .HasColumnName(nameof(Manufacturer.Name));

                b.Property(x => x.Title).IsRequired().HasMaxLength(ManufacturerConsts.MaxTitleLength)
                    .HasColumnName(nameof(Manufacturer.Title));

                b.Property(x => x.Description).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxDescriptionLength)
                    .HasColumnName(nameof(Manufacturer.Description));

                b.Property(x => x.MetaTitle).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxMetaTitleLength)
                    .HasColumnName(nameof(Manufacturer.MetaTitle));

                b.Property(x => x.MetaKeywords).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxMetaKeywordsLength)
                    .HasColumnName(nameof(Manufacturer.MetaKeywords));

                b.Property(x => x.MetaDescription).IsRequired(false)
                    .HasMaxLength(ManufacturerConsts.MaxMetaDescriptionLength)
                    .HasColumnName(nameof(Manufacturer.MetaDescription));

                b.Property(x => x.PageSize).HasColumnName(nameof(Manufacturer.PageSize));

                b.Property(x => x.IsAllowCustomersToSelectPageSize).HasDefaultValue(true)
                    .HasColumnName(nameof(Manufacturer.AllowCustomersToSelectPageSize));

                b.Property(x => x.PageSizeOptions).HasColumnName(nameof(Manufacturer.PageSizeOptions));

                b.Property(x => x.IsPublished).HasDefaultValue(false).HasColumnName(nameof(Manufacturer.IsPublished));

                b.Property(x => x.ShowOnHomePage).HasDefaultValue(false)
                    .HasColumnName(nameof(Manufacturer.ShowOnHomePage));

                b.Property(x => x.DisplayOrder).HasDefaultValue(0).HasColumnName(nameof(Manufacturer.DisplayOrder));

                b.HasOne<Template>().WithMany().IsRequired().HasForeignKey(x => x.ManufacturerTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany<ManufacturerDiscount>().WithOne().HasForeignKey(x => x.ManufacturerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ManufacturerDiscount>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers_ManufacturerDiscount", options.Schema);

                b.Property(x => x.ManufacturerId).HasColumnName(nameof(ManufacturerDiscount.ManufacturerId));
                b.Property(x => x.DiscountId).HasColumnName(nameof(ManufacturerDiscount.DiscountId));

                b.HasKey(x => new {x.ManufacturerId, x.DiscountId});
            });
        }
    }
}