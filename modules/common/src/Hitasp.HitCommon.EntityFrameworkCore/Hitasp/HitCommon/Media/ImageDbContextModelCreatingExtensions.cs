using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.Media
{
    public static class ImageDbContextModelCreatingExtensions
    {
        public static void ConfigureImages(
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
                b.ToTable(tablePrefix + "Media_Images", schema);
                b.HasKey(x => x.Id);
                
                b.ConfigureAsMedia();

                b.Property(x => x.MimeType).HasColumnName(nameof(Image.MimeType));
                b.Property(x => x.BinaryData).HasColumnName(nameof(Image.BinaryData));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(Image.DisplayOrder));

            });
        }
    }
}