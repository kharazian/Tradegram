using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.Seo
{
    public static class SeoDbContextModelCreatingExtensions
    {
        public static void ConfigureSeo<TSeoSupport>(this EntityTypeBuilder<TSeoSupport> b)
            where TSeoSupport : Entity, ISlugSupported
        {
            b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ISlugSupported.Name));
            b.Property(x => x.Slug).IsRequired().HasColumnName(nameof(ISlugSupported.Slug));
        }
    }
}