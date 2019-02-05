using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Mapping;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductInventory
    {
        public virtual int StockQuantity { get; protected set; }
        public virtual Guid? WarehouseId { get; protected set; }
        public virtual bool UseMultipleWarehouses { get; protected set; }
        public virtual bool DisplayStockAvailability { get; set; }
        public virtual bool DisplayStockQuantity { get; set; }
        public virtual int MinStockQuantity { get; set; }
        public virtual bool AllowBackInStockSubscriptions { get; set; }
        public virtual int OrderMinimumQuantity { get; protected set; }
        public virtual int OrderMaximumQuantity { get; protected set; }
        public virtual string AllowedQuantities { get; protected set; }
        public virtual bool NotReturnable { get; set; }
        
        public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; protected set; }

        public virtual void SetOrderQuantityLimitation(int orderMinimumQuantity, int orderMaximumQuantity)
        {
            if (orderMinimumQuantity <= 0 ||
                orderMaximumQuantity <= 0 ||
                orderMaximumQuantity < orderMinimumQuantity)
            {
                orderMinimumQuantity = 1;
                orderMaximumQuantity = int.MaxValue;
            }

            OrderMinimumQuantity = orderMinimumQuantity;
            OrderMaximumQuantity = orderMaximumQuantity;
        }

        public virtual void SetAllowedQuantities(string allowedQuantities = "")
        {
            AllowedQuantities = string.Empty;

            if (string.IsNullOrWhiteSpace(allowedQuantities))
            {
                return;
            }

            var validQuantities = allowedQuantities.Split(",").Select(int.Parse).ToArray();

            if (!validQuantities.Any())
            {
                return;
            }

            AllowedQuantities = string.Join(",", validQuantities);
        }

        public virtual void SetWarehouse(Guid productId,Guid? warehouseId)
        {
            if (warehouseId == null || warehouseId == Guid.Empty)
            {
                WarehouseId = null;

                return;
            }

            if (UseMultipleWarehouses & ProductWarehouseInventories.Any())
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(productId, warehouseId.Value));

                return;
            }

            WarehouseId = warehouseId;
        }

        public virtual void SetMultipleWarehouses(Guid productId, IEnumerable<Guid> warehouseInventoryIds)
        {
            var hashSet = new HashSet<Guid>(warehouseInventoryIds);

            if (hashSet.Count <= 1)
            {
                UseMultipleWarehouses = false;
                SetWarehouse(productId, hashSet.FirstOrDefault());

                return;
            }

            UseMultipleWarehouses = true;
            WarehouseId = null;

            foreach (var warehouseInventoryId in hashSet)
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(productId, warehouseInventoryId));
            }

            if (StockQuantity > 0)
            {
                ProductWarehouseInventories.First().SetStockQuantity(StockQuantity);
            }

            StockQuantity = 0;
        }

        public virtual void RemoveWarehouse(Guid warehouseId)
        {
            if (ProductWarehouseInventories.All(x => x.WarehouseId != warehouseId))
            {
                return;
            }

            var totalStockQuantity = ProductWarehouseInventories.Where(x => x.WarehouseId == warehouseId)
                .Sum(x => x.StockQuantity);

            if (totalStockQuantity > 0)
            {
                SetStockQuantity(StockQuantity + totalStockQuantity);
            }

            ProductWarehouseInventories.RemoveAll(x => x.WarehouseId == warehouseId);
        }

        internal void SetStockQuantity(int stockQuantity)
        {
            StockQuantity = stockQuantity;
        }
        
        protected ProductInventory()
        {
            ProductWarehouseInventories = new HashSet<ProductWarehouseInventory>();
        }

        public ProductInventory(int stockQuantity)
        {
            SetStockQuantity(stockQuantity);
        }
    }
}