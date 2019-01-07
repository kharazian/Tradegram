using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductLink : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid LinkedProductId { get; protected set; }

        public virtual ProductLinkType LinkType { get; protected set; }

        protected ProductLink()
        {
        }

        public ProductLink(Guid productId, Guid linkedProductId, ProductLinkType linkType)
        {
            ProductId = productId;
            LinkedProductId = linkedProductId;
            LinkType = linkType;
        }

        public override object[] GetKeys()
        {
            return new object[]{ProductId, LinkedProductId};
        }
    }
}
