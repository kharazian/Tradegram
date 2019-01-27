using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductProductTag : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid ProductTagId { get; protected set; }

        protected ProductProductTag()
        {
        }

        internal ProductProductTag(Guid productId, Guid productTagId)
        {
            ProductId = productId;
            ProductTagId = productTagId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, ProductTagId};
        }
    }
}