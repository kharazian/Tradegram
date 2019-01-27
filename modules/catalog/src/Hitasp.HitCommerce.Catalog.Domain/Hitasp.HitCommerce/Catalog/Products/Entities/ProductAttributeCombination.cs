using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductAttributeCombination : Entity<Guid>
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid? PictureId { get; protected set; }
        
        public virtual string ManufacturerPartNumber { get; set; }

        public virtual string Code { get; set; }

        public virtual int StockQuantity { get; set; }

        public virtual bool AllowOutOfStockOrders { get; set; }

        public virtual string Gtin { get; set; }

        public virtual decimal? OverriddenPrice { get; set; }

        public virtual int NotifyAdminForQuantityBelow { get; set; }

        public virtual string AttributesXml { get; set; }


        protected ProductAttributeCombination()
        {
        }

        internal ProductAttributeCombination(Guid id, Guid productId) : base(id)
        {
            ProductId = productId;
        }

        public void SetPicture(Guid pictureId)
        {
            if (PictureId == pictureId)
            {
                return;
            }

            PictureId = pictureId;
        }
    }
}