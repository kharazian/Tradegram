using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.Models
{
    public abstract class ContentItem : FullAuditedAggregateRoot<Guid>, ISlugSupported
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Slug { get; protected set; }
        
        public virtual string Description { get; protected set; }

        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        public virtual bool IsPublished { get; protected set; }
        
        public virtual Guid? PictureId { get; protected set; }

        public DateTime? PublishedOn { get; protected set; }
        
        public virtual int DisplayOrder { get; set; }

        protected ContentItem()
        {
            
        }

        protected ContentItem(
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
        
        public virtual void SetPicture(Guid pictureId)
        {
            PictureId = pictureId;
        }

        public virtual void SetDescription(string description)
        {
            Description = description;
        }
    }
}
