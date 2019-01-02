using Hitasp.HitCommerce.Seo;
using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class HitSeoDbContextModelCreatingExtensions
    {
        public static void ConfigureSeo(this EntityTypeBuilder<UrlRecord> b, ModelBuilderConfigurationOptions options)
        {
            b.ToTable(options.TablePrefix + "UrlRecords", options.Schema);
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.EntityId);

                
            b.Property(x => x.EntityName).IsRequired().HasMaxLength(SeoConsts.MaxNameLength)
                .HasColumnName(nameof(UrlRecord.EntityName));
            b.Property(x => x.Slug).IsRequired().HasMaxLength(SeoConsts.MaxSlugLength)
                .HasColumnName(nameof(UrlRecord.Slug));
            b.Property(x => x.EntityId).IsRequired().HasColumnName(nameof(UrlRecord.EntityId));
            b.Property(x => x.IsActive).HasDefaultValue(true).HasColumnName(nameof(UrlRecord.IsActive));
        }
    }
}