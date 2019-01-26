using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public class SpecificationAttribute : Entity<Guid>
    {
        public virtual Guid? SpaceId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOptions { get; protected set; }

        protected SpecificationAttribute()
        {
            SpecificationAttributeOptions = new HashSet<SpecificationAttributeOption>();
        }

        public SpecificationAttribute(Guid id, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Id = id;
            Name = name;

            SpecificationAttributeOptions = new HashSet<SpecificationAttributeOption>();
        }
        
        public void SetSpaceId(Guid? spaceId)
        {
            if (spaceId == Guid.NewGuid() || spaceId == null)
            {
                SpaceId = null;
                return;
            }

            if (SpaceId == spaceId)
            {
                return;
            }

            SpaceId = spaceId;
        }

        public void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= AttributeConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {AttributeConsts.MaxNameLength}");
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
        }
        
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}