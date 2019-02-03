using System;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class GiftCard : Product
    {
        public virtual int GiftCardTypeId { get; protected set; }
        public virtual decimal? OverriddenGiftCardAmount { get; protected set; }

        public GiftCardType GiftCardType
        {
            get => (GiftCardType) GiftCardTypeId;
            set => GiftCardTypeId = (int) value;
        }

        protected GiftCard()
        {
        }

        public GiftCard(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription,
            decimal price, int giftCardTypeId, decimal? overriddenGiftCardAmount) 
            : base(id, code, name, shortDescription, price)
        {
            GiftCardTypeId = giftCardTypeId;
            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }

        public virtual void SetAsGiftCard(bool isGiftCard = true, int? giftCardTypeId = null,
            decimal? overriddenGiftCardAmount = null)
        {
            if (isGiftCard && giftCardTypeId.HasValue)
            {
                switch (giftCardTypeId)
                {
                    case 0:
                        IsGiftCard = true;
                        GiftCardTypeId = (int) giftCardTypeId;
                        SetShippingEnabled(false);

                        //TODO: is virtual! disable all physical prop!
                        break;
                    case 1:
                        IsGiftCard = true;
                        GiftCardTypeId = (int) giftCardTypeId;
                        SetShippingEnabled();

                        //TODO: is physical! disable all virtual prop! 
                        break;
                    default:
                        IsGiftCard = true;
                        GiftCardTypeId = 0;
                        SetShippingEnabled(false);

                        //TODO: is virtual! disable all physical prop!
                        break;
                }

                if (overriddenGiftCardAmount <= decimal.Zero || overriddenGiftCardAmount == null)
                {
                    OverriddenGiftCardAmount = decimal.Zero;
                }

                return;
            }

            IsGiftCard = false;
            GiftCardTypeId = 0;
            OverriddenGiftCardAmount = decimal.Zero;
        }
    }
}