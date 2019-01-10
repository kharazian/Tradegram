using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.Assets
{
    public static class AssetDbContextModelCreatingExtensions
    {
        public static void ConfigureAsset<TAsset>(this EntityTypeBuilder<TAsset> b)
            where TAsset : AssetBase
        {
            b.ConfigureSeo();
            
            b.ConfigureAudited();

            b.HasIndex(x => x.UniqueName).IsUnique();
            
            b.Property(x => x.LanguageCode).HasColumnName(nameof(AssetBase.LanguageCode));
            
            b.Property(x => x.GroupName).IsRequired().HasColumnName(nameof(AssetBase.GroupName));
            b.Property(x => x.Extension).HasColumnName(nameof(AssetBase.Extension));
            b.Property(x => x.UniqueName).IsRequired().HasColumnName(nameof(AssetBase.UniqueName));
            b.Property(x => x.TypeId).HasColumnName(nameof(AssetBase.TypeId));
            b.Property(x => x.Url).HasColumnName(nameof(AssetBase.Url));
            b.Property(x => x.RelativeUrl).HasColumnName(nameof(AssetBase.RelativeUrl));
        }
    }
}