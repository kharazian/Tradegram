using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public class UrlRecord : AggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual Guid EntityId { get; protected set; }

        [NotNull]
        public virtual string ContentItemTypeId { get; protected set; }
        
        public virtual bool IsActive { get; protected internal set; }
        

        protected UrlRecord()
        {
        }

        public UrlRecord(
            Guid id,
            Guid entityId,
            [NotNull] string contentItemTypeId,
            [NotNull] string name,
            [NotNull] string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(contentItemTypeId, nameof(contentItemTypeId));
            
            Id = id;
            EntityId = entityId;
            ContentItemTypeId = contentItemTypeId;
            Name = name;
            Slug = slug;
            IsActive = true;
        }
    }
}