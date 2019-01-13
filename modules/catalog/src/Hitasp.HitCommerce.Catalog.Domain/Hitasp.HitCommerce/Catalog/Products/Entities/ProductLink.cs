using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
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

        public virtual void SetLinkType(ProductLinkType linkType)
        {
            LinkType = linkType;
        }

        public override object[] GetKeys()
        {
            return new object[]{ProductId, LinkedProductId};
        }
    }
}
