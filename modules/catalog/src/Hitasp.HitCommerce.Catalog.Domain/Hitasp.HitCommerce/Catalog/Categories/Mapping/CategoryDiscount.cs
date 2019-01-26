using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Categories.Mapping
{
    public class CategoryDiscount : Entity
    {
        public virtual Guid CategoryId { get; protected set; }

        public virtual Guid DiscountId { get; protected set; }

        protected CategoryDiscount()
        {
        }

        internal CategoryDiscount(Guid categoryId, Guid discountId)
        {
            CategoryId = categoryId;
            DiscountId = discountId;
        }

        public override object[] GetKeys()
        {
            return new object[] {CategoryId, DiscountId};
        }
    }
}