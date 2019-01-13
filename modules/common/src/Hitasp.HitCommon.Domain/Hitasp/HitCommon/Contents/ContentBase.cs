using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Localization;

namespace Hitasp.HitCommon.Contents
{
    public abstract class ContentBase : FullAuditedAggregateRoot<Guid>, IHasLanguage, ISlugSupported
    {
        public string Name { get; protected set; }

        public string Slug { get; protected set; }

        public string Description { get; protected set; }

        public string MetaTitle { get; protected set; }

        public string MetaKeywords { get; protected set; }

        public string MetaDescription { get; protected set; }

        public bool IsPublished { get; protected set; }

        public Guid? PictureId { get; protected set; }

        public DateTime? PublishedOn { get; protected set; }

        public int DisplayOrder { get; protected set; }

        public string LanguageCode { get; protected set; }
        

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

        public virtual void SetAsPublished(bool publish = true)
        {
            if (publish && PublishedOn.HasValue)
            {
                //skip changing publish date
                IsPublished = true;
                return;
            }

            if (publish)
            {
                PublishedOn = DateTime.Now;
            }
            
            IsPublished = publish;
        }

        public virtual void SetPicture(Guid pictureId)
        {
            PictureId = pictureId;
        }

        public virtual void SetDescription(string description)
        {
            Description = description;
        }

        public abstract void SetDisplayOrder(int displayOrder);
        
        public abstract void SetLanguageCode(string languageCode);
    }
}