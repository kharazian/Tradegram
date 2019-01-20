using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class ContentBaseDbContextModelCreatingExtensions
    {
        public static void ConfigureAsContent<TContent>(this EntityTypeBuilder<TContent> b)
            where TContent : Content
        {
            b.ConfigureFullAudited();
            b.HasIndex(x => x.SpaceId);

            b.Property(x => x.SpaceId).HasColumnName(nameof(Content.SpaceId));
            b.Property(x => x.Name).IsRequired().HasMaxLength(ContentConsts.MaxNameLength)
                .HasColumnName(nameof(Content.Name));
            b.Property(x => x.Title).IsRequired().HasMaxLength(ContentConsts.MaxTitleLength)
                .HasColumnName(nameof(Content.Title));
            b.Property(x => x.Description).HasMaxLength(ContentConsts.MaxDescriptionLength)
                .HasColumnName(nameof(Content.Description));
            b.Property(x => x.MetaTitle).HasMaxLength(ContentConsts.MaxMetaTitleLength)
                .HasColumnName(nameof(Content.MetaTitle));
            b.Property(x => x.MetaKeywords).HasMaxLength(ContentConsts.MaxMetaKeywordsLength)
                .HasColumnName(nameof(Content.MetaKeywords));
            b.Property(x => x.MetaDescription).HasMaxLength(ContentConsts.MaxTitleLength)
                .HasColumnName(nameof(Content.MetaDescription));
            b.Property(x => x.IsPublished).HasColumnName(nameof(Content.IsPublished));
        }
    }
}