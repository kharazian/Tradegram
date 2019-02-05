namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductBasePrice
    {
        public virtual decimal BasePriceAmount { get; protected set; }
        public virtual int BasePriceUnitId { get; protected set; }
        public virtual decimal BasePriceBaseAmount { get; protected set; }
        public virtual int BasePriceBaseUnitId { get; protected set; }

        protected ProductBasePrice()
        {
        }

        public ProductBasePrice(decimal basePriceAmount, int basePriceUnitId,
            decimal basePriceBaseAmount, int basePriceBaseUnitId)
        {
            BasePriceAmount = basePriceAmount;
            BasePriceUnitId = basePriceUnitId;
            BasePriceBaseAmount = basePriceBaseAmount;
            BasePriceBaseUnitId = basePriceBaseUnitId;
        }
    }
}