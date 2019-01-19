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
            b.HasIndex(x => x.UniqueName).IsUnique();

            b.ConfigureAudited();
            
            b.Property(x => x.Url).HasColumnName(nameof(Asset.Url));
            b.Property(x => x.FileName).IsRequired().HasColumnName(nameof(Asset.FileName));
            b.Property(x => x.Extension).IsRequired().HasColumnName(nameof(Asset.Extension));
            b.Property(x => x.MimeType).IsRequired().HasColumnName(nameof(Asset.MimeType));
            b.Property(x => x.UniqueName).IsRequired().HasColumnName(nameof(Asset.UniqueName));
        }
    }
}