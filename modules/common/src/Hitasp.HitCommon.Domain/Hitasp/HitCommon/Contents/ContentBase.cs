using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Localization;

namespace Hitasp.HitCommon.Contents
{
    public abstract class ContentBase : FullAuditedAggregateRoot<Guid>, IHasMetaData, IHasLanguage, ISlugSupported
    {
        [NotNull] 
        public string Name { get; protected set; }

        [NotNull]
        public string Slug { get; protected set; }

        public string Description { get; protected set; }

        public string MetaTitle { get; protected set; }

        public string MetaKeywords { get; protected set; }

        public string MetaDescription { get; protected set; }

        public bool IsPublished { get; protected set; }

        public Guid? ImageId { get; protected set; }

        public DateTime? PublishedOn { get; protected set; }

        public int DisplayOrder { get; set; }

        public string LanguageCode { get; set; }

        protected ContentBase(
            Guid id,
            [NotNull] string name,
            [NotNull] string slug,
            [CanBeNull] string description)
        {
            Id = id;
            Name = name;
            Slug = slug;
            Description = description;
        }

        protected virtual void Publish()
        {
            IsPublished = true;
            PublishedOn = DateTime.Now;
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

        public virtual void ChangePublishStatus(bool status = false)
        {
            if (!IsPublished && status)
            {
                Publish();

                return;
            }

            IsPublished = status;
        }

        public virtual void SetPicture(Guid imageId)
        {
            ImageId = imageId;
        }

        public virtual void SetDescription(string description)
        {
            Description = description;
        }
    }
}