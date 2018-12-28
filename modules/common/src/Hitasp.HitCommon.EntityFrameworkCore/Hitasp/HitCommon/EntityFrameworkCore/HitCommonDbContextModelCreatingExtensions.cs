using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class HitCommonDbContextModelCreatingExtensions
    {
        public static void ConfigureHitSeo<TUrlRecord>(this EntityTypeBuilder<TUrlRecord> b, ModelBuilderConfigurationOptions options)
            where TUrlRecord : class, IUrlRecord
        {
            b.Property(u => u.EntityId).HasColumnName(nameof(IUrlRecord.EntityId));
            b.Property(u => u.EntityName).HasMaxLength(SeoConsts.MaxNameLength).HasColumnName(nameof(IUrlRecord.EntityName));
            b.Property(u => u.Slug).HasMaxLength(SeoConsts.MaxSlugLength).HasColumnName(nameof(IUrlRecord.Slug));
            b.Property(u => u.IsActive).HasDefaultValue(true).HasColumnName(nameof(IUrlRecord.IsActive));
        }
    }
}