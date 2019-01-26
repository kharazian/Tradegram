using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductCategory : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid CategoryId { get; protected set; }

        public virtual bool IsFeaturedProduct { get; set; }

        public virtual int DisplayOrder { get; set; }

        protected ProductCategory()
        {
        }

        internal ProductCategory(Guid productId, Guid categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, CategoryId};
        }
    }
}