using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductTag : CreationAuditedEntity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid TagId { get; protected set; }

        protected ProductTag()
        {
        }

        public ProductTag(Guid productId, Guid tagId)
        {
            ProductId = productId;
            TagId = tagId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, TagId};
        }
    }
}