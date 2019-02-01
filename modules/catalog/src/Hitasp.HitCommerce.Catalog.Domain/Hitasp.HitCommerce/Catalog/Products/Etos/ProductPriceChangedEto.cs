using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Hitasp.HitCommerce.Catalog.Products.Etos
{
    [Serializable]
    public class ProductPriceChangedEto : EtoBase
    {
        public decimal OldPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        private ProductPriceChangedEto()
        {
        }

        public ProductPriceChangedEto(decimal oldPrice, decimal currentPrice)
        {
            OldPrice = oldPrice;
            CurrentPrice = currentPrice;
        }
    }
}