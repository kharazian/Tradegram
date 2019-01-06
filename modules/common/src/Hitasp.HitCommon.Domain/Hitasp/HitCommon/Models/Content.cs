using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.Models
{
    public abstract class Content : FullAuditedAggregateRoot<Guid>, ISlugSupported
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        public virtual bool IsPublished { get; protected set; }

        public DateTimeOffset? PublishedOn { get; protected set; }

        protected Content()
        {
            
        }

        protected Content(Guid id, [NotNull] string name, [NotNull] string slug)
        {
            Id = id;
            Name = name;
            Slug = slug;
        }

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
        
        public virtual void ChangePublishStatus()
        {
            if (!IsPublished)
            {
                Publish();
            }
            
            IsPublished = false;
        }
    }
}
