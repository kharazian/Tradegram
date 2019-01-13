using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductTemplateAttribute : CreationAuditedEntity
    {
        public virtual Guid ProductTemplateId { get; protected set; }

        public virtual Guid AttributeId { get; protected set; }

        protected ProductTemplateAttribute()
        {
        }

        public ProductTemplateAttribute(Guid productTemplateId, Guid attributeId)
        {
            ProductTemplateId = productTemplateId;
            AttributeId = attributeId;
        }

        public override object[] GetKeys()
        {
            return new object[]{ProductTemplateId, AttributeId};
        }
    }
}
