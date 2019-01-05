using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductMedia : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid MediaId { get; protected set; }

        public virtual int DisplayOrder { get; set; }

        protected ProductMedia()
        {
        }

        public ProductMedia(Guid productId, Guid mediaId)
        {
            ProductId = productId;
            MediaId = mediaId;
        }

        public override object[] GetKeys()
        {
            return new object[]{ProductId, MediaId};
        }
    }
}
