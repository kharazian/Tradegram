using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes.Entities
{
    public class ProductAttribute : Entity<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= AttributeConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {AttributeConsts.MaxNameLength}");
            }

            Name = name;
        }
        
        public virtual void SetDescription(string description)
        {
            if (description.Length >= AttributeConsts.MaxDescriptionLength)
            {
                throw new ArgumentException($"Description can not be longer than {AttributeConsts.MaxDescriptionLength}");
            }

            Description = description;
        }
        
        protected ProductAttribute()
        {
        }

        public ProductAttribute(Guid id, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Id = id;
            Name = name;
        }
    }
}