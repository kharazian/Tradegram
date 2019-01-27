using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities
{
    public class SpecificationAttributeOption : Entity<Guid>
    {
        public virtual Guid SpecificationAttributeId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string ColorSquaresRgb { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        protected SpecificationAttributeOption()
        {
        }

        public SpecificationAttributeOption(Guid id, Guid specificationAttributeId, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Id = id;
            SpecificationAttributeId = specificationAttributeId;
            Name = name;
        }

        public void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= SpecificationAttributeConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {SpecificationAttributeConsts.MaxNameLength}");
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
        }
        
        public void SetColorSquaresRgb(string colorSquaresRgb)
        {
            if (colorSquaresRgb.Length >= SpecificationAttributeConsts.MaxColorSquaresRgbLength)
            {
                throw new ArgumentException(
                    $"{nameof(colorSquaresRgb)} can not be longer than {SpecificationAttributeConsts.MaxColorSquaresRgbLength}");
            }

            ColorSquaresRgb = colorSquaresRgb;
        }

        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}