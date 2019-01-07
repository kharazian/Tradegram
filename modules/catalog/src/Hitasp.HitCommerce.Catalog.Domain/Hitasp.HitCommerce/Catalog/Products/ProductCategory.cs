using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductCategory : Entity
    {
        public Guid ProductId { get; protected set; }

        public Guid CategoryId { get; protected set; }

        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }

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
    }
}