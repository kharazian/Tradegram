using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductWarehouseInventory : Entity
    {
        public virtual Guid ProductId { get; private set; }

        public virtual Guid WarehouseId { get; private set; }

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

        internal void SetStockQuantity(int stockQuantity)
        {
            StockQuantity = stockQuantity;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, WarehouseId};
        }
    }
}