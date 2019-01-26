using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductTag : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid TagId { get; protected set; }

        protected ProductTag()
        {
        }

        internal ProductTag(Guid productId, Guid tagId)
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