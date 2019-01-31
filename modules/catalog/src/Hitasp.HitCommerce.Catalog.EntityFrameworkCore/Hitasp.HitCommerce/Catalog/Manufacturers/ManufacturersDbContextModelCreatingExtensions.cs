using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

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

                b.Property(x => x.ManufacturerTemplateId).IsRequired().HasColumnName(nameof(Manufacturer.ManufacturerTemplateId));
                b.Property(x => x.PictureId).HasColumnName(nameof(Manufacturer.PictureId));

                b.HasOne<ManufacturerInfo>().WithOne().IsRequired().HasForeignKey<ManufacturerInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasOne<ManufacturerMetaInfo>().WithOne().IsRequired().HasForeignKey<ManufacturerMetaInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasOne<ManufacturerPageInfo>().WithOne().IsRequired().HasForeignKey<ManufacturerPageInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                b.HasOne<ManufacturerPublishingInfo>().WithOne().IsRequired().HasForeignKey<ManufacturerPublishingInfo>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Template>().WithMany().IsRequired().HasForeignKey(x => x.ManufacturerTemplateId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany<ManufacturerDiscount>().WithOne().HasForeignKey(x => x.ManufacturerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            builder.Entity<ManufacturerInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers_Info", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.Name).IsRequired().HasMaxLength(ManufacturerConsts.MaxNameLength)
                    .HasColumnName(nameof(ManufacturerInfo.Name));
                b.Property(x => x.Title).IsRequired().HasMaxLength(ManufacturerConsts.MaxTitleLength)
                    .HasColumnName(nameof(ManufacturerInfo.Title));
                b.Property(x => x.Description).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxDescriptionLength)
                    .HasColumnName(nameof(ManufacturerInfo.Description));

            });
            
            builder.Entity<ManufacturerMetaInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers_Meta", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.MetaTitle).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxMetaTitleLength)
                    .HasColumnName(nameof(ManufacturerMetaInfo.MetaTitle));
                b.Property(x => x.MetaKeywords).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxMetaKeywordsLength)
                    .HasColumnName(nameof(ManufacturerMetaInfo.MetaKeywords));
                b.Property(x => x.MetaDescription).IsRequired(false).HasMaxLength(ManufacturerConsts.MaxMetaDescriptionLength)
                    .HasColumnName(nameof(ManufacturerMetaInfo.MetaDescription));
            });
            
            builder.Entity<ManufacturerPageInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers_PageInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.PageSize).HasColumnName(nameof(ManufacturerPageInfo.PageSize));
                b.Property(x => x.IsAllowCustomersToSelectPageSize).HasDefaultValue(true)
                    .HasColumnName(nameof(ManufacturerPageInfo.AllowCustomersToSelectPageSize));
                b.Property(x => x.PageSizeOptions).HasColumnName(nameof(ManufacturerPageInfo.PageSizeOptions));
            });
            
            builder.Entity<ManufacturerPublishingInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers_PublishingInfo", options.Schema);

                b.HasKey(x => x.Id);

                b.Property(x => x.IsPublished).HasDefaultValue(false).HasColumnName(nameof(ManufacturerPublishingInfo.IsPublished));
                b.Property(x => x.ShowOnHomePage).HasDefaultValue(false).HasColumnName(nameof(ManufacturerPublishingInfo.ShowOnHomePage));
                b.Property(x => x.DisplayOrder).HasDefaultValue(0).HasColumnName(nameof(ManufacturerPublishingInfo.DisplayOrder));
            });
            
            builder.Entity<ManufacturerDiscount>(b =>
            {
                b.ToTable(options.TablePrefix + "Manufacturers_ManufacturerDiscount", options.Schema);

                b.Property(x => x.ManufacturerId).HasColumnName(nameof(ManufacturerDiscount.ManufacturerId));
                b.Property(x => x.DiscountId).HasColumnName(nameof(ManufacturerDiscount.DiscountId));

                b.HasKey(x => new { x.ManufacturerId, x.DiscountId });
            });
        }
    }
}