using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Mapping;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductInventory
    {
        public virtual int StockQuantity { get; protected set; }
        public virtual Guid? WarehouseId { get; protected internal set; }
        public virtual bool UseMultipleWarehouses { get; protected internal set; }
        public virtual bool DisplayStockAvailability { get; set; }
        public virtual bool DisplayStockQuantity { get; set; }
        public virtual int MinStockQuantity { get; set; }
        public virtual bool AllowBackInStockSubscriptions { get; set; }
        public virtual int OrderMinimumQuantity { get; protected set; }
        public virtual int OrderMaximumQuantity { get; protected set; }
        public virtual string AllowedQuantities { get; protected set; }
        public virtual bool NotReturnable { get; set; }
        
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

        internal void SetStockQuantity(int stockQuantity)
        {
            StockQuantity = stockQuantity;
        }
        
        protected ProductInventory()
        {
        }

        public ProductInventory(int stockQuantity)
        {
            SetStockQuantity(stockQuantity);
        }
    }
}