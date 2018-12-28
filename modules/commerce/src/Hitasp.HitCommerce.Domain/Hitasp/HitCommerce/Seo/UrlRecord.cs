using System;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectMapping;

namespace Hitasp.HitCommerce.Seo
{
    public class UrlRecord : AggregateRoot<Guid>, IUrlRecord, IMapTo<SeoEto>
    {
        [NotNull] 
        public virtual string EntityName { get; protected set; }
        
        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual Guid EntityId { get; protected set; }
        
        public virtual bool IsActive { get; protected internal set; }

        protected UrlRecord()
        {
        }

        public UrlRecord(Guid id, Guid entityId, [NotNull] string entityName, [NotNull] string slug, bool isActive)
        {
            Id = id;
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
            EntityName = Check.NotNullOrWhiteSpace(entityName, nameof(entityName));
            EntityId = entityId;
            IsActive = isActive;
        }

        public SeoEto MapTo()
        {
            return new SeoEto
            {
                Id = Id,
                EntityId = EntityId,
                EntityName = EntityName,
                IsActive = IsActive
            };
        }

        public void MapTo(SeoEto destination)
        {
            destination.Id = Id;
            destination.EntityId = EntityId;
            destination.EntityName = EntityName;
            destination.IsActive = IsActive;
        }
    }
}