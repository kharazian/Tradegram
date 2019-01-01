using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.Models
{
    public abstract class Content : FullAuditedAggregateRoot<Guid>, ISlugSupported
    {
        public string Name { get; protected set; }

        public string Slug { get; protected set; }

        public string MetaTitle { get; protected set; }

        public string MetaKeywords { get; protected set; }

        public string MetaDescription { get; protected set; }

        public bool IsPublished { get; protected set; }

        public DateTimeOffset? PublishedOn { get; protected set; }

        protected virtual void Publish()
        {
            IsPublished = true;
            PublishedOn = DateTimeOffset.Now;
        }

        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetSlug([NotNull] string slug)
        {
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
        }
        
        public virtual void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }
    }
}
