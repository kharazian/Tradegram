using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Etos;
using Hitasp.HitCommerce.Catalog.Products.Mapping;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class PhysicalProduct : Product
    {
        public virtual string Gtin { get; protected set; }

        public virtual int StockQuantity { get; protected set; }

        public virtual bool IsDisplayStockAvailability { get; protected set; }

        public virtual bool IsDisplayStockQuantity { get; protected set; }

        public virtual bool IsAllowBackInStockSubscriptions { get; protected set; }

        public virtual LowStockActivity LowStockActivity { get; protected set; }

        public virtual ManageInventoryMethod ManageInventoryMethod { get; protected set; }

        public virtual int MinStockQuantity { get; protected set; }

        public virtual int NotifyAdminForQuantityBelow { get; protected set; }

        public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; protected set; }


        protected PhysicalProduct()
        {
            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductTags = new HashSet<ProductTag>();
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            AttributeCombinations = new HashSet<ProductAttributeCombination>();
            CrossSellProducts = new HashSet<CrossSellProduct>();
            RelatedProducts = new HashSet<RelatedProduct>();

            ProductWarehouseInventories = new HashSet<ProductWarehouseInventory>();
        }

        internal PhysicalProduct(Guid id)
        {
            Id = id;

            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductTags = new HashSet<ProductTag>();
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            AttributeCombinations = new HashSet<ProductAttributeCombination>();
            CrossSellProducts = new HashSet<CrossSellProduct>();
            RelatedProducts = new HashSet<RelatedProduct>();

            ProductWarehouseInventories = new HashSet<ProductWarehouseInventory>();
        }


        public void SetGtin(string gtin)
        {
            if (Gtin == gtin)
            {
                return;
            }

            if (gtin.Length > ProductConsts.MaxGtinLength)
            {
                throw new ArgumentException($"Gtin can not be longer than {ProductConsts.MaxGtinLength}");
            }

            Gtin = gtin;
        }

        public void RemoveStock(int quantityDesired)
        {
            if (StockQuantity == 0)
                throw new ArgumentException($"Empty stock, product item {ProductInfo.Name} is sold out");

            if (quantityDesired <= 0)
                throw new ArgumentException("Item units desired should be greater than zero");

            var removed = Math.Min(quantityDesired, StockQuantity);

            SetStockCountInternal(StockQuantity - removed);
        }

        public void AddStock(int quantity = 0)
        {
            SetStockCountInternal(StockQuantity - quantity);
        }

        public void AddProductWarehouse(Guid warehouseId)
        {
            ProductWarehouseInventories.Add(new ProductWarehouseInventory(Id, warehouseId));
        }

        public void ProductWarehouse(Guid warehouseId)
        {
            if (ProductWarehouseInventories.Any(x => x.WarehouseId == warehouseId))
            {
                ProductWarehouseInventories.RemoveAll(x => x.WarehouseId == warehouseId);
            }
        }

        private void SetStockCountInternal(int stockCount, bool triggerEvent = true)
        {
            if (stockCount < 0.0f)
            {
                throw new ArgumentException($"{nameof(stockCount)} can not be less than 0!");
            }

            if (StockQuantity == stockCount)
            {
                return;
            }

            //sample distributed event
            if (triggerEvent)
            {
                AddDistributedEvent(new ProductStockQuantityChangedEto(StockQuantity, stockCount));
            }

            StockQuantity = stockCount;
        }

        public void SetAsDisplayStockAvailability(bool isDisplayStockAvailability = true)
        {
            if (IsDisplayStockAvailability == isDisplayStockAvailability)
            {
                return;
            }

            IsDisplayStockAvailability = isDisplayStockAvailability;
        }

        public void SetAsDisplayStockQuantity(bool isDisplayStockQuantity = true)
        {
            if (IsDisplayStockQuantity == isDisplayStockQuantity)
            {
                return;
            }

            IsDisplayStockQuantity = isDisplayStockQuantity;
        }

        public void SetAsAllowBackInStockSubscriptions(bool isAllowBackInStockSubscriptions = true)
        {
            if (IsAllowBackInStockSubscriptions == isAllowBackInStockSubscriptions)
            {
                return;
            }

            IsAllowBackInStockSubscriptions = isAllowBackInStockSubscriptions;
        }

        public void SetManageInventoryMethod(
            ManageInventoryMethod manageInventoryMethod = ManageInventoryMethod.ManageStock,
            LowStockActivity lowStockActivity = LowStockActivity.Nothing,
            int? minStockQuantity = null, int? notifyAdminForQuantityBelow = null)
        {
            switch (manageInventoryMethod)
            {
                case ManageInventoryMethod.ManageStock when minStockQuantity < 0 || minStockQuantity == null:

                    throw new ArgumentException($"Can not manage inventory without valid {nameof(minStockQuantity)}!");
                case ManageInventoryMethod.ManageStock
                    when notifyAdminForQuantityBelow == null || notifyAdminForQuantityBelow < 0:

                    throw new ArgumentException($"{nameof(notifyAdminForQuantityBelow)} in not valid!");
                case ManageInventoryMethod.ManageStock:
                    SetLowStockActivity(lowStockActivity);
                    MinStockQuantity = minStockQuantity.Value;
                    NotifyAdminForQuantityBelow = notifyAdminForQuantityBelow.Value;
                    ManageInventoryMethod = manageInventoryMethod;

                    break;
                case ManageInventoryMethod.DontManageStock:
                    SetLowStockActivity();
                    ManageInventoryMethod = manageInventoryMethod;

                    break;

                case ManageInventoryMethod.ManageStockByAttributes
                    when minStockQuantity < 0 || minStockQuantity == null:

                    throw new ArgumentException($"Can not manage inventory without valid {nameof(minStockQuantity)}!");
                case ManageInventoryMethod.ManageStockByAttributes
                    when notifyAdminForQuantityBelow == null || notifyAdminForQuantityBelow < 0:

                    throw new ArgumentException($"{nameof(notifyAdminForQuantityBelow)} in not valid!");
                case ManageInventoryMethod.ManageStockByAttributes:
                    SetLowStockActivity(lowStockActivity);
                    MinStockQuantity = minStockQuantity.Value;
                    NotifyAdminForQuantityBelow = notifyAdminForQuantityBelow.Value;
                    ManageInventoryMethod = manageInventoryMethod;

                    break;
                default:

                    throw new ArgumentOutOfRangeException(nameof(manageInventoryMethod), manageInventoryMethod, null);
            }
        }

        private void SetLowStockActivity(LowStockActivity lowStockActivity = LowStockActivity.Nothing)
        {
            if (LowStockActivity == lowStockActivity)
            {
                return;
            }

            LowStockActivity = lowStockActivity;
        }
    }
}