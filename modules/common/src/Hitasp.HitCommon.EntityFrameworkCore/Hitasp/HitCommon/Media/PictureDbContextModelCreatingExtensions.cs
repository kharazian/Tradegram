using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.Media
{
    public static class PictureDbContextModelCreatingExtensions
    {
        public static void ConfigurePictures(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }

            builder.Entity<Picture>(b =>
            {
                b.ToTable(tablePrefix + "Media_Pictures", schema);
                b.HasKey(x => x.Id);
                
                b.ConfigureAsMedia();

                b.Property(x => x.MimeType).HasColumnName(nameof(Picture.MimeType));
                b.Property(x => x.BinaryData).HasColumnName(nameof(Picture.BinaryData));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(Picture.DisplayOrder));

            });
        }
    }
}