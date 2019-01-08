using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductTag : Entity
    {
        public Guid ProductId { get; set; }

        public Guid ProductTagId { get; set; }
        
        public override object[] GetKeys()
        {
            throw new System.NotImplementedException();
        }
    }
}