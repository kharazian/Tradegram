using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductBasePrice : Entity
    {
        public virtual Guid ProductId { get; private set; }
        public virtual decimal BasePriceAmount { get; protected set; }
        public virtual int BasePriceUnitId { get; protected set; }
        public virtual decimal BasePriceBaseAmount { get; protected set; }
        public virtual int BasePriceBaseUnitId { get; protected set; }

        protected ProductBasePrice()
        {
        }

        public ProductBasePrice(Guid productId, decimal basePriceAmount, int basePriceUnitId,
            decimal basePriceBaseAmount, int basePriceBaseUnitId)
        {
            ProductId = productId;
            BasePriceAmount = basePriceAmount;
            BasePriceUnitId = basePriceUnitId;
            BasePriceBaseAmount = basePriceBaseAmount;
            BasePriceBaseUnitId = basePriceBaseUnitId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}