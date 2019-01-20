using Hitasp.HitCommon.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class AssetBaseDbContextModelCreatingExtensions
    {
        public static void ConfigureAsAsset<TAsset>(this EntityTypeBuilder<TAsset> b)
            where TAsset : Asset
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.SpaceId);

            b.ConfigureAudited();

            b.Property(x => x.SpaceId).HasColumnName(nameof(Asset.SpaceId));
            b.Property(x => x.Url).IsRequired().HasMaxLength(AssetConsts.MaxUrlLength)
                .HasColumnName(nameof(Asset.Url));
            b.Property(x => x.FileName).IsRequired().HasMaxLength(AssetConsts.MaxFileNameLength)
                .HasColumnName(nameof(Asset.FileName));
            b.Property(x => x.Extension).IsRequired().HasColumnName(nameof(Asset.Extension));
            b.Property(x => x.MimeType).IsRequired().HasMaxLength(AssetConsts.MaxMimeTypeLength)
                .HasColumnName(nameof(Asset.MimeType));
            b.Property(x => x.UniqueName).IsRequired().HasColumnName(nameof(Asset.UniqueName));
        }
    }
}