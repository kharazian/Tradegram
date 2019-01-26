using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Hitasp.HitCommerce.Catalog.Products.Etos
{
    //sample distributed event
    [Serializable]
    public class ProductStockQuantityChangedEto : EtoBase
    {
        public int OldCount { get; set; }

        public int CurrentCount { get; set; }

        private ProductStockQuantityChangedEto()
        {
        }

        public ProductStockQuantityChangedEto(int oldCount, int currentCount)
        {
            OldCount = oldCount;
            CurrentCount = currentCount;
        }
    }
}