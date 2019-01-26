using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class CrossSellProduct : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid CrossSellProductId { get; protected set; }

        protected CrossSellProduct()
        {
        }

        internal CrossSellProduct(Guid productId, Guid crossSellProductId)
        {
            ProductId = productId;
            CrossSellProductId = crossSellProductId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, CrossSellProductId};
        }
    }
}