using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public class CatalogAttribute : Entity<Guid>
    {
        public virtual Guid? SpaceId { get; protected set; }
        
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        protected CatalogAttribute()
        {
        }

        public CatalogAttribute(Guid id, [NotNull] string name, Guid? spaceId = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Id = id;
            Name = name;
            SpaceId = spaceId;
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
        
        public void SetDescription(string description)
        {
            if (description.Length >= AttributeConsts.MaxDescriptionLength)
            {
                throw new ArgumentException($"Description can not be longer than {AttributeConsts.MaxDescriptionLength}");
            }

            if (Description == description)
            {
                return;
            }

            Description = description;
        }
    }
}