using Hitasp.HitCommerce.Seo;
using Hitasp.HitCommon.Medias;
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
                b.HasIndex(x => x.EntityId).IsUnique();

                
                b.Property(x => x.EntityName).IsRequired().HasMaxLength(SeoConsts.MaxNameLength)
                    .HasColumnName(nameof(UrlRecord.EntityName));
                b.Property(x => x.Slug).IsRequired().HasMaxLength(SeoConsts.MaxSlugLength)
                    .HasColumnName(nameof(UrlRecord.Slug));
                b.Property(x => x.EntityId).IsRequired().HasColumnName(nameof(UrlRecord.EntityId));
                b.Property(x => x.IsActive).HasDefaultValue(true).HasColumnName(nameof(UrlRecord.IsActive));
            });
        }
    }
}