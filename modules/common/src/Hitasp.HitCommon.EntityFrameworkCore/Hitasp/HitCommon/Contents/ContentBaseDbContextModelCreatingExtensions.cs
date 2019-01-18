using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.Contents
{
    public static class ContentBaseDbContextModelCreatingExtensions
    {
        public static void ConfigureAsContent<TContent>(this EntityTypeBuilder<TContent> b)
            where TContent : ContentBase
        {
            b.ConfigureFullAudited();
            b.ConfigureSeo();
            
            b.Property(x => x.Description).HasColumnName(nameof(ContentBase.Description));
            b.Property(x => x.MetaTitle).HasColumnName(nameof(ContentBase.MetaTitle));
            b.Property(x => x.MetaKeywords).HasColumnName(nameof(ContentBase.MetaKeywords));
            b.Property(x => x.MetaDescription).HasColumnName(nameof(ContentBase.MetaDescription));
            b.Property(x => x.IsPublished).HasColumnName(nameof(ContentBase.IsPublished));
            b.Property(x => x.PictureId).IsRequired().HasColumnName(nameof(ContentBase.PictureId));
            b.Property(x => x.PublishedOn).HasColumnName(nameof(ContentBase.PublishedOn));
            b.Property(x => x.DisplayOrder).HasColumnName(nameof(ContentBase.DisplayOrder));
        }
    }
}