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

            
            b.Property(x => x.Title).HasColumnName(nameof(Content.Title));
            b.Property(x => x.Description).HasColumnName(nameof(Content.Description));
            b.Property(x => x.MetaTitle).HasColumnName(nameof(Content.MetaTitle));
            b.Property(x => x.MetaKeywords).HasColumnName(nameof(Content.MetaKeywords));
            b.Property(x => x.MetaDescription).HasColumnName(nameof(Content.MetaDescription));
            b.Property(x => x.IsPublished).HasColumnName(nameof(Content.IsPublished));
        }
    }
}