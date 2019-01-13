using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductCategory : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid CategoryId { get; protected set; }

        public virtual bool IsFeaturedProduct { get; protected set; }

        public virtual int DisplayOrder { get; set; }

        protected ProductCategory()
        {
        }

        public ProductCategory(Guid productId, Guid categoryId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, CategoryId};
        }

        public virtual void SetAsFeaturedProduct(bool isFeaturedProduct = true)
        {
            IsFeaturedProduct = isFeaturedProduct;
        }
    }
}