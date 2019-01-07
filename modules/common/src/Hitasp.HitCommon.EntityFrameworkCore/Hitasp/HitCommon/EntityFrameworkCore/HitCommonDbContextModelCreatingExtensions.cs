using Hitasp.HitCommon.Medias;
using Hitasp.HitCommon.Models;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class HitCommonDbContextModelCreatingExtensions
    {
        public static void ConfigureHitCommon(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }

            builder.Entity<Media>(b =>
            {
                b.ToTable(tablePrefix + "Media", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.UniqueFileName).IsUnique();


                b.Property(x => x.FileExtension).HasColumnName(nameof(Media.FileExtension));
                b.Property(x => x.FileName).IsRequired().HasColumnName(nameof(Media.FileName));
                b.Property(x => x.RootDirectory).IsRequired().HasColumnName(nameof(Media.RootDirectory));
                b.Property(x => x.UniqueFileName).HasColumnName(nameof(Media.UniqueFileName));
                b.Property(x => x.MimeType).HasColumnName(nameof(Media.MimeType));
            });

            builder.Entity<UrlRecord>(b =>
            {
                b.ToTable(tablePrefix + "UrlRecords", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.ContentItemTypeId);


                b.Property(x => x.Name).IsRequired().HasMaxLength(SeoConsts.MaxNameLength)
                    .HasColumnName(nameof(UrlRecord.Name));

                b.Property(x => x.Slug).IsRequired().HasMaxLength(SeoConsts.MaxSlugLength)
                    .HasColumnName(nameof(UrlRecord.Slug));

                b.Property(x => x.EntityId).IsRequired().HasColumnName(nameof(UrlRecord.EntityId));
                b.Property(x => x.ContentItemTypeId).IsRequired().HasColumnName(nameof(UrlRecord.ContentItemTypeId));
                b.Property(x => x.IsActive).HasDefaultValue(true).HasColumnName(nameof(UrlRecord.IsActive));
            });

            builder.Entity<ContentItemType>(b =>
            {
                b.ToTable(tablePrefix + "ContentItemTypes", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.AreaName);


                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ContentItemType.Name));
                b.Property(x => x.IsMenuable).HasDefaultValue(false).HasColumnName(nameof(ContentItemType.IsMenuable));

                b.Property(x => x.AreaName).HasMaxLength(ModelConsts.MaxAreaNameLength)
                    .HasColumnName(nameof(ContentItemType.AreaName));

                b.Property(x => x.RoutingController).HasMaxLength(ModelConsts.MaxRoutingControllerLength)
                    .HasColumnName(nameof(ContentItemType.RoutingController));

                b.Property(x => x.RoutingAction).HasMaxLength(ModelConsts.MaxRoutingActionLength)
                    .HasColumnName(nameof(ContentItemType.RoutingAction));
            });
        }
    }
}