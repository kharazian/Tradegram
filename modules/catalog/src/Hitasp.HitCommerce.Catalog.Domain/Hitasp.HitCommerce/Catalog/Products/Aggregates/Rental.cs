using System;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Rental : Product
    {
        public int RentalPriceLength { get; protected set; }
        public int RentalPricePeriodId { get; protected set; }

        public RentalPricePeriod RentalPricePeriod
        {
            get => (RentalPricePeriod) RentalPricePeriodId;
            protected set => RentalPricePeriodId = (int) value;
        }

        public void SetAsRental(int rentalPriceLength, int rentalPricePeriodId)
        {
            if (rentalPriceLength <= 0)
            {
                throw new ArgumentException($"{nameof(rentalPriceLength)} is not valid!");
            }

            RentalPriceLength = rentalPriceLength;
            RentalPricePeriodId = rentalPricePeriodId;
            IsRecurring = false;
            IsRental = true;
        }
    }
}