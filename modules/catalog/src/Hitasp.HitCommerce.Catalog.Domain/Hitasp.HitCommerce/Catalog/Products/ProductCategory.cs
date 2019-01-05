using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductCategory : Entity
    {
        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }

        public Guid CategoryId { get; set; }

        public Guid ProductId { get; set; }

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