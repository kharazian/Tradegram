using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Attributes;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities
{
    public class SpecificationAttribute : Entity<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOptions { get; protected set; }

        
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= AttributeConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {AttributeConsts.MaxNameLength}");
            }

            Name = name;
        }

        public virtual void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
        
        protected SpecificationAttribute()
        {
            SpecificationAttributeOptions = new HashSet<SpecificationAttributeOption>();
        }

        public SpecificationAttribute(Guid id, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Id = id;
            Name = name;
        }
    }
}