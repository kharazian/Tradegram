using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public class SpecificationAttributeOption : AggregateRoot<Guid>
    {
        public virtual Guid SpecificationAttributeId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string ColorSquaresRgb { get; protected set; }

        public virtual int DisplayOrder { get; set; }

        protected SpecificationAttributeOption()
        {
        }

        public SpecificationAttributeOption(Guid specificationAttributeId, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            
            SpecificationAttributeId = specificationAttributeId;
            Name = name;
        }

        public virtual void SetSpecificationAttribute(Guid specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }
        
        public virtual void SetColorSquares([NotNull] string colorSquares)
        {
            Check.NotNullOrWhiteSpace(colorSquares, nameof(colorSquares));

            ColorSquaresRgb = colorSquares;
        }
    }
}