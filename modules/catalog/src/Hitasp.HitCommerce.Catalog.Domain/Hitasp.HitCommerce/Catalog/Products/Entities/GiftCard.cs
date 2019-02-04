using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class GiftCard : Entity
    {
        public virtual Guid ProductId { get; private set; }
        public virtual int GiftCardTypeId { get; private set; }
        public virtual decimal? OverriddenGiftCardAmount { get; protected set; }

        public virtual GiftCardType GiftCardType
        {
            get => (GiftCardType) GiftCardTypeId;
            protected set => GiftCardTypeId = (int) value;
        }

        public virtual void ChangeOverriddenGiftCardAmount(decimal overriddenGiftCardAmount)
        {
            if (overriddenGiftCardAmount <= decimal.Zero)
            {
                OverriddenGiftCardAmount = decimal.Zero;

                return;
            }

            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }

        protected GiftCard()
        {
        }

        public GiftCard(Guid productId, int giftCardTypeId, decimal? overriddenGiftCardAmount)
        {
            ProductId = productId;
            GiftCardTypeId = giftCardTypeId;
            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}