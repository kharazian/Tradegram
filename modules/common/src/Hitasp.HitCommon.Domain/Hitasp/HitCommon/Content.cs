using System;
using Hitasp.HitCommon.Seo;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon
{
    public abstract class Content : FullAuditedAggregateRoot<Guid>, ISlugSupported
    {
        public string Name { get; set; }

        public string Slug { get; set; }

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

        public abstract void SetMetaData(string metaTitle, string metaKeywords, string metaDescription);
    }
}
