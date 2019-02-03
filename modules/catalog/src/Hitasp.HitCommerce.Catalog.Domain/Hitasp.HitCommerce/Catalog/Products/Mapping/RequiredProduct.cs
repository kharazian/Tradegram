using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class RequiredProduct : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid RequiredProductId { get; protected set; }

        public virtual bool AutomaticallyAddRequiredProducts { get; set; }

        protected RequiredProduct()
        {
        }

        internal RequiredProduct(Guid productId, Guid requiredProductId)
        {
            ProductId = productId;
            RequiredProductId = requiredProductId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, RequiredProductId};
        }
    }
}