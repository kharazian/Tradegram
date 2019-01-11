using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public class Attribute : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual Guid ProductAttributeGroupId { get; protected set; }

        
        protected Attribute()
        {
        }

        public Attribute([NotNull] string name, Guid productAttributeGroupId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
            ProductAttributeGroupId = productAttributeGroupId;
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }

        public virtual void SetAttributeGroup(Guid attributeGroupId)
        {
            ProductAttributeGroupId = attributeGroupId;
        }
    }
}
