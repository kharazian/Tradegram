using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductRate : Entity<Guid>
    {
        public virtual double RatingAverage { get; protected set; }

        public virtual int RatingCount { get; protected set; }

        protected ProductRate()
        {
        }

        internal ProductRate(Guid productId) : base(productId)
        {
        }

        public void UpdateRatingAverage(double newRate)
        {
            var average = (RatingAverage * RatingCount + newRate) / (RatingCount + 1);
            RatingAverage = Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2;
            
            IncreaseRatingCount();
        }

        private void IncreaseRatingCount()
        {
            RatingCount++;
        }
    }
}