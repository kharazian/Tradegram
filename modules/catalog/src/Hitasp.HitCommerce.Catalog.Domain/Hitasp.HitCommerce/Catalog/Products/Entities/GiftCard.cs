using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class GiftCard : Entity
    {
        public Guid ProductId { get; private set; }
        public int GiftCardTypeId { get; private set; }
        public decimal? OverriddenGiftCardAmount { get; protected set; }

        public GiftCardType GiftCardType
        {
            get => (GiftCardType) GiftCardTypeId;
            protected set => GiftCardTypeId = (int) value;
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

        public void ChangeOverriddenGiftCardAmount(decimal overriddenGiftCardAmount)
        {
            if (overriddenGiftCardAmount <= decimal.Zero)
            {
                OverriddenGiftCardAmount = decimal.Zero;

                return;
            }

            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}