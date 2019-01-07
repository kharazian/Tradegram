using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class Brand : AggregateRoot<Guid>, ISlugSupported
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual bool IsPublished { get; protected set; }

        protected Brand()
        {
        }

        public Brand(Guid id, [NotNull] string name, [NotNull] string slug, [CanBeNull] string description = null)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Description = description;
        }

        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetSlug([NotNull] string slug)
        {
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
        }
        
        public virtual void ChangePublishStatus(bool status = true)
        {
            IsPublished = status;
        }

        public virtual void SetDescription(string description)
        {
            Description = description;
        }
    }
}
