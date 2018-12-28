using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Vendors
{
    public class Vendor : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual string Description { get; set; }

        public virtual string Email { get; set; }

        public virtual bool IsActive { get; set; }

        protected Vendor()
        {
        }

        public Vendor(Guid id, [NotNull] string name, [NotNull] string slug)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetSlug([NotNull] string slug)
        {
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
        }
    }
}
