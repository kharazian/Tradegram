using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductPicture : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid PictureId { get; protected set; }

        public virtual int DisplayOrder { get; set; }

        protected ProductPicture()
        {
        }

        public ProductPicture(Guid productId, Guid pictureId)
        {
            ProductId = productId;
            PictureId = pictureId;
        }

        public override object[] GetKeys()
        {
            return new object[]{ProductId, PictureId};
        }
    }
}
