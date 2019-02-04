using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    //TODO: protect set accessors same as productBase
    public class ProductAttributeCombination : Entity
    {
        public virtual Guid ProductId { get; private set; }

        public virtual Guid? PictureId { get; set; }

        public virtual string ManufacturerPartNumber { get; set; }

        public virtual string Code { get; set; }

        public virtual int StockQuantity { get; set; }

        public virtual bool AllowOutOfStockOrders { get; set; }

        public virtual string Gtin { get; set; }

        public virtual decimal? OverriddenPrice { get; set; }

        public virtual string AttributesXml { get; set; }


        protected ProductAttributeCombination()
        {
        }

        public ProductAttributeCombination(Guid productId, Guid? pictureId, string code, int stockQuantity)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
            {
                throw new ArgumentException("");
            }
            ProductId = productId;
            PictureId = pictureId;
            
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}