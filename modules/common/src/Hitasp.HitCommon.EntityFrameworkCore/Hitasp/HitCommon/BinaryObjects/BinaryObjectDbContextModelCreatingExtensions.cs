using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.BinaryObjects
{
    public static class BinaryObjectDbContextModelCreatingExtensions
    {
        public static void ConfigureBinaryObjects(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }

            builder.Entity<ThumbnailImage>(b =>
            {
                b.ToTable(tablePrefix + "BinaryObjects", schema);
                b.HasKey(x => x.Id);

                b.ConfigureCreationAudited();

                b.Property(x => x.FileName).IsRequired().HasColumnName(nameof(ThumbnailImage.FileName));
                b.Property(x => x.MimeType).IsRequired().HasColumnName(nameof(ThumbnailImage.MimeType));

                b.Property(x => x.BinaryData).IsRequired().HasMaxLength(BinaryObjectConsts.MaxThumbnailBinaryLength)
                    .HasColumnName(nameof(ThumbnailImage.BinaryData));

                b.Property(x => x.DisplayOrder).HasColumnName(nameof(ThumbnailImage.DisplayOrder));
            });
        }
    }
}