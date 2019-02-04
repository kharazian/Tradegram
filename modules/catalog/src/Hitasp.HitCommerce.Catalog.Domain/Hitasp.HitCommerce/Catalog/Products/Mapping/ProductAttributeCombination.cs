using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductAttributeCombination : Entity<Guid>
    {
        public virtual Guid ProductId { get; private set; }

        public virtual Guid? PictureId { get; set; }

        public virtual string ManufacturerPartNumber { get; set; }

        public virtual string Code { get; private set; }

        public virtual int StockQuantity { get; protected set; }

        public virtual bool AllowOutOfStockOrders { get; set; }

        public virtual string Gtin { get; set; }

        public virtual decimal? OverriddenPrice { get; set; }

        public virtual string AttributesXml { get; set; }


        protected ProductAttributeCombination()
        {
        }

        public ProductAttributeCombination(Guid id, Guid productId, string code, int stockQuantity)
            : base(id)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
            {
                throw new ArgumentException($"Code can not be longer than {ProductConsts.MaxCodeLength}");
            }

            if (stockQuantity < 0)
            {
                stockQuantity = 0;
            }

            ProductId = productId;
            Code = code;
            SetStockQuantity(stockQuantity);
        }

        internal void SetStockQuantity(int stockQuantity)
        {
            StockQuantity = stockQuantity;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}