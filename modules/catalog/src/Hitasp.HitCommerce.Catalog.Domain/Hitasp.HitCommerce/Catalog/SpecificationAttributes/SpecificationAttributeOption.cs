using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes
{
    public class SpecificationAttributeOption : AggregateRoot<Guid>
    {
        public Guid SpecificationAttributeId { get; set; }

        public string Name { get; set; }

        public string ColorSquaresRgb { get; set; }

        public int DisplayOrder { get; set; }
    }
}