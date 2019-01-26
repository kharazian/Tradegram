using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class RelatedProduct : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid RelatedProductId { get; protected set; }

        protected RelatedProduct()
        {
        }

        internal RelatedProduct(Guid productId, Guid relatedProductId)
        {
            ProductId = productId;
            RelatedProductId = relatedProductId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, RelatedProductId};
        }
    }
}