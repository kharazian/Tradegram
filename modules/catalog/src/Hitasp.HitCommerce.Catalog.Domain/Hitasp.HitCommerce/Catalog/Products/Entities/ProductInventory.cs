using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductInventory : Entity
    {
        public Guid ProductId { get; private set; }
        public int StockQuantity { get; protected set; }
        public Guid? WarehouseId { get; protected set; }
        public bool UseMultipleWarehouses { get; protected set; }
        public bool DisplayStockAvailability { get; set; }
        public bool DisplayStockQuantity { get; set; }
        public int MinStockQuantity { get; set; }
        public bool AllowBackInStockSubscriptions { get; set; }
        public int OrderMinimumQuantity { get; protected set; }
        public int OrderMaximumQuantity { get; protected set; }
        public string AllowedQuantities { get; protected set; }
        public bool NotReturnable { get; set; }
        
        public ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; protected set; }

        protected ProductInventory()
        {
            ProductWarehouseInventories = new HashSet<ProductWarehouseInventory>();
        }

        public ProductInventory(Guid productId)
        {
            ProductId = productId;
        }

        public void SetOrderQuantityLimitation(int orderMinimumQuantity, int orderMaximumQuantity)
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

        public void SetAllowedQuantities(string allowedQuantities = "")
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

        public void SetWarehouse(Guid? warehouseId)
        {
            if (warehouseId == null || warehouseId == Guid.Empty)
            {
                WarehouseId = null;

                return;
            }

            if (UseMultipleWarehouses & ProductWarehouseInventories.Any())
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(ProductId, warehouseId.Value));

                return;
            }

            WarehouseId = warehouseId;
        }

        public void SetMultipleWarehouses(IEnumerable<Guid> warehouseInventoryIds)
        {
            var hashSet = new HashSet<Guid>(warehouseInventoryIds);

            if (hashSet.Count <= 1)
            {
                UseMultipleWarehouses = false;
                SetWarehouse(hashSet.FirstOrDefault());

                return;
            }

            UseMultipleWarehouses = true;
            WarehouseId = null;

            foreach (var warehouseInventoryId in hashSet)
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(ProductId, warehouseInventoryId));
            }

            if (StockQuantity > 0)
            {
                ProductWarehouseInventories.First().SetStockQuantity(StockQuantity);
            }

            StockQuantity = 0;
        }

        public void RemoveWarehouse(Guid warehouseId)
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

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}