using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
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

            builder.Entity<Image>(b =>
            {
                b.ToTable(tablePrefix + "Media_Image", schema);
                b.HasKey(x => x.Id);
                
                b.ConfigureAsset();

                b.Property(x => x.MimeType).HasColumnName(nameof(Image.MimeType));
                b.Property(x => x.BinaryData).HasColumnName(nameof(Image.BinaryData));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(Image.DisplayOrder));

            });

            builder.Entity<UrlRecord>(b =>
            {
                b.ToTable(tablePrefix + "UrlRecords", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.EntityTypeId);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(UrlRecord.Name));
                b.Property(x => x.Slug).IsRequired().HasColumnName(nameof(UrlRecord.Slug));

                b.Property(x => x.EntityId).IsRequired().HasColumnName(nameof(UrlRecord.EntityId));
                b.Property(x => x.EntityTypeId).IsRequired().HasColumnName(nameof(UrlRecord.EntityTypeId));
                b.Property(x => x.IsActive).HasDefaultValue(true).HasColumnName(nameof(UrlRecord.IsActive));
            });
            
            builder.Entity<EntityType>(b =>
            {
                b.ToTable(tablePrefix + "EntityTypes", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.AreaName);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(EntityType.Name));
                b.Property(x => x.AreaName).HasColumnName(nameof(EntityType.AreaName));
                b.Property(x => x.RoutingAction).HasColumnName(nameof(EntityType.RoutingAction));
                b.Property(x => x.RoutingController).HasColumnName(nameof(EntityType.RoutingController));
                b.Property(x => x.IsMenuable).HasDefaultValue(false).HasColumnName(nameof(EntityType.IsMenuable));
            });
        }
    }
}