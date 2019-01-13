using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public class UrlRecord : AggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        
        public virtual string Slug { get; protected set; }

        public virtual Guid EntityId { get; protected set; }

        public virtual string EntityTypeId { get; protected set; }
        
        public virtual bool IsActive { get; protected internal set; }
        

        protected UrlRecord()
        {
        }

        public UrlRecord(
            Guid id,
            Guid entityId,
            [NotNull] string entityTypeId,
            [NotNull] string name,
            [NotNull] string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(entityTypeId, nameof(entityTypeId));

            
            Id = id;
            EntityId = entityId;
            EntityTypeId = entityTypeId;
            Name = name;
            Slug = slug;
            IsActive = true;
        }
    }
}