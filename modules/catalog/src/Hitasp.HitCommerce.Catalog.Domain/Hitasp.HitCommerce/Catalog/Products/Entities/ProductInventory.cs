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
        public int ManageInventoryMethodId { get; protected set; }

        public ManageInventoryMethod ManageInventoryMethod
        {
            get => (ManageInventoryMethod) ManageInventoryMethodId;
            protected set => ManageInventoryMethodId = (int) value;
        }

        public int StockQuantity { get; protected set; }
        public Guid? WarehouseId { get; protected set; }
        public bool UseMultipleWarehouses { get; protected set; }
        public int ProductAvailabilityRangeId { get; protected set; }
        public bool DisplayStockAvailability { get; protected set; }
        public bool DisplayStockQuantity { get; protected set; }

        public int MinStockQuantity { get; set; }
        public int LowStockActivityId { get; protected set; }

        public LowStockActivity LowStockActivity
        {
            get => (LowStockActivity) LowStockActivityId;
            protected set => LowStockActivityId = (int) value;
        }

        public int NotifyAdminForQuantityBelow { get; protected set; }
        public int BackorderModeId { get; protected set; }

        public BackorderMode BackorderMode
        {
            get => (BackorderMode) BackorderModeId;
            protected set => BackorderModeId = (int) value;
        }

        public bool AllowBackInStockSubscriptions { get; set; }
        public int OrderMinimumQuantity { get; protected set; }
        public int OrderMaximumQuantity { get; protected set; }

        public void SetOrderQuantityLimitation(int orderMinimumQuantity, int orderMaximumQuantity)
        {
            if (orderMinimumQuantity <= 0 || orderMaximumQuantity <= 0 || orderMaximumQuantity < orderMinimumQuantity)
            {
                orderMinimumQuantity = 1;
                orderMaximumQuantity = int.MaxValue;
            }

            OrderMinimumQuantity = orderMinimumQuantity;
            OrderMaximumQuantity = orderMaximumQuantity;
        }

        public string AllowedQuantities { get; protected set; }

        public void SetAllowedQuantities(IEnumerable<int> allowedQuantities)
        {
            allowedQuantities = allowedQuantities.Distinct().ToArray();

            AllowedQuantities = string.Empty;

            AllowedQuantities = string.Join(",", allowedQuantities);
        }

        public bool NotReturnable { get; set; }
        public ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; protected set; }

        public void SetManageInventoryMethod(int manageInventoryMethodId = 0)
        {
            var manageMethod = (ManageInventoryMethod) manageInventoryMethodId;

            switch (manageMethod)
            {
                case ManageInventoryMethod.ManageStock:
                    ManageInventoryMethod = manageMethod;

                    break;

                case ManageInventoryMethod.DontManageStock:
                    ManageInventoryMethod = manageMethod;
                    UseMultipleWarehouses = false;
                    DisplayStockQuantity = false;
                    DisplayStockAvailability = false;
                    LowStockActivity = LowStockActivity.Nothing;
                    BackorderMode = BackorderMode.NoBackorders;
                    AllowBackInStockSubscriptions = false;
                    ProductAvailabilityRangeId = 0;

                    break;

                case ManageInventoryMethod.ManageStockByAttributes:
                    ManageInventoryMethod = manageMethod;

                    break;

                default:

                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetWarehouse(Guid? warehouseId)
        {
            if (warehouseId == null || warehouseId == Guid.Empty)
            {
                WarehouseId = null;

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
            StockQuantity = 0;
            WarehouseId = null;

            if (ManageInventoryMethod == ManageInventoryMethod.DontManageStock)
            {
                SetManageInventoryMethod();
            }

            foreach (var warehouseInventoryId in hashSet)
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(ProductId, warehouseInventoryId));
            }
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}