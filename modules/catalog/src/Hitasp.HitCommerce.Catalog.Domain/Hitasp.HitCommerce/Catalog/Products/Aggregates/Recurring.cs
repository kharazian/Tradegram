using System;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Recurring : Product
    {
        public virtual int RecurringCycleLength { get; protected set; }
        public virtual int RecurringCyclePeriodId { get; protected set; }
        public virtual int RecurringTotalCycles { get; protected set; }

        public RecurringProductCyclePeriod RecurringCyclePeriod
        {
            get => (RecurringProductCyclePeriod) RecurringCyclePeriodId;
            protected set => RecurringCyclePeriodId = (int) value;
        }

        public virtual void SetAsRecurring(int recurringCycleLength, int recurringTotalCycles,
            int recurringCyclePeriodId)
        {
            if (recurringCycleLength <= 0)
            {
                throw new ArgumentException($"{nameof(recurringCycleLength)} is not valid!");
            }

            if (recurringTotalCycles <= 0)
            {
                throw new ArgumentException($"{nameof(recurringTotalCycles)} is not valid!");
            }

            RecurringCycleLength = recurringCycleLength;
            RecurringTotalCycles = recurringTotalCycles;
            RecurringCyclePeriodId = recurringCyclePeriodId;
            IsRental = false;
            IsRecurring = true;
        }
    }
}