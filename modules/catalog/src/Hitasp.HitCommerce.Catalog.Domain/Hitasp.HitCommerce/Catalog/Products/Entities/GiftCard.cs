namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class GiftCard
    {
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

        public GiftCard(int giftCardTypeId, decimal? overriddenGiftCardAmount)
        {
            GiftCardTypeId = giftCardTypeId;
            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }
    }
}