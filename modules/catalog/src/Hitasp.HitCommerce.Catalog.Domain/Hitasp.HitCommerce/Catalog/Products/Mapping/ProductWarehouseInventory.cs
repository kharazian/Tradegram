using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductWarehouseInventory : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid WarehouseId { get; protected set; }

        public virtual int StockQuantity { get; protected set; }

        public virtual int ReservedQuantity { get; protected set; }

        protected ProductWarehouseInventory()
        {
        }

        internal ProductWarehouseInventory(Guid productId, Guid warehouseId)
        {
            ProductId = productId;
            WarehouseId = warehouseId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, WarehouseId};
        }
    }
}