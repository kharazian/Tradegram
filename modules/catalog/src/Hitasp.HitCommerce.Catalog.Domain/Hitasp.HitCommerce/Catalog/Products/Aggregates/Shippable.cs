using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Etos;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Shippable : Product
    {
        #region GiftCard

        public virtual bool IsGiftCard { get; protected set; }
        public virtual int GiftCardTypeId { get; protected set; }
        public virtual decimal? OverriddenGiftCardAmount { get; protected set; }

        public virtual GiftCardType GiftCardType => (GiftCardType) GiftCardTypeId;

        public virtual void ChangeOverriddenGiftCardAmount(decimal overriddenGiftCardAmount)
        {
            if (overriddenGiftCardAmount <= decimal.Zero)
            {
                OverriddenGiftCardAmount = decimal.Zero;

                return;
            }

            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }
        
        public virtual void SetAsGiftCard(bool isGiftCard, decimal? overriddenGiftCardAmount = null)
        {
            if (overriddenGiftCardAmount <= decimal.Zero || overriddenGiftCardAmount == null)
            {
                overriddenGiftCardAmount = decimal.Zero;
            }

            GiftCardTypeId = (int) GiftCardType.Physical;
            IsGiftCard = isGiftCard;
            OverriddenGiftCardAmount = overriddenGiftCardAmount;
        }

        #endregion

        #region Inventory

        public virtual ProductInventory Inventory { get; protected set; }
        
        public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; protected set; }


        public virtual void RemoveStock(int quantityDesired, Guid? warehouseId = null)
        {
            if (Inventory.UseMultipleWarehouses && warehouseId == null)
                throw new ArgumentException(
                    $"{nameof(warehouseId)} must be a valid identity!");

            if (!Inventory.UseMultipleWarehouses && Inventory.StockQuantity == 0)
                throw new ArgumentException($"Empty stock, product item {Name} is sold out");

            if (quantityDesired <= 0)
                throw new ArgumentException("Item units desired should be greater than zero");

            var removed = Math.Min(quantityDesired, Inventory.StockQuantity);

            SetStockQuantityInternal(Inventory.StockQuantity - removed, warehouseId);
        }

        public virtual void AddStock(int quantity = 0, Guid? warehouseId = null)
        {
            if (quantity < 0) return;

            SetStockQuantityInternal(Inventory.StockQuantity + quantity, warehouseId);
        }

        private void SetStockQuantityInternal(int quantity, Guid? warehouseId = null, bool triggerEvent = true)
        {
            if (warehouseId.HasValue && warehouseId != Guid.Empty)
            {
                var warehouseInventory =
                     ProductWarehouseInventories.First(x => x.WarehouseId == warehouseId);

                if (warehouseInventory != null)
                {
                    if (warehouseInventory.StockQuantity == 0)
                        throw new ArgumentException($"Empty stock, product item {Name} is sold out");

                    if (warehouseInventory.StockQuantity == quantity) return;

                    //sample distributed event
                    if (triggerEvent)
                        AddDistributedEvent(
                            new ProductStockQuantityChangedEto(Inventory.StockQuantity, quantity));

                    ProductWarehouseInventories.First(x => x.WarehouseId == warehouseId)
                        .SetStockQuantity(quantity);

                    return;
                }
            }

            if (Inventory.StockQuantity == quantity) return;

            //sample distributed event
            if (triggerEvent)
                AddDistributedEvent(new ProductStockQuantityChangedEto(Inventory.StockQuantity, quantity));

            Inventory.SetStockQuantity(quantity);
        }
        
        public virtual void SetWarehouse(Guid productId,Guid? warehouseId)
        {
            if (warehouseId == null || warehouseId == Guid.Empty)
            {
                Inventory.WarehouseId = null;

                return;
            }

            if (Inventory.UseMultipleWarehouses & ProductWarehouseInventories.Any())
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(productId, warehouseId.Value));

                return;
            }

            Inventory.WarehouseId = warehouseId;
        }

        public virtual void SetMultipleWarehouses(Guid productId, IEnumerable<Guid> warehouseInventoryIds)
        {
            var hashSet = new HashSet<Guid>(warehouseInventoryIds);

            if (hashSet.Count <= 1)
            {
                Inventory.UseMultipleWarehouses = false;
                SetWarehouse(productId, hashSet.FirstOrDefault());

                return;
            }

            Inventory.UseMultipleWarehouses = true;
            Inventory.WarehouseId = null;

            foreach (var warehouseInventoryId in hashSet)
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(productId, warehouseInventoryId));
            }

            if (Inventory.StockQuantity > 0)
            {
                ProductWarehouseInventories.First().SetStockQuantity(Inventory.StockQuantity);
            }

            Inventory.SetStockQuantity(0);
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
                Inventory.SetStockQuantity(Inventory.StockQuantity + totalStockQuantity);
            }

            ProductWarehouseInventories.RemoveAll(x => x.WarehouseId == warehouseId);
        }

        #endregion

        #region Shipping

        public virtual bool IsShipEnabled { get; protected set; }
        public virtual ProductShipping Shipping { get; protected set; }

        public virtual void EnableShipping(bool isShipEnabled = true, bool isFreeShipping = true, decimal additionalShippingCharge = decimal.Zero)
        {
            if (isShipEnabled)
            {
                Shipping.SetShipping(isFreeShipping, additionalShippingCharge);
            }

            IsShipEnabled = isShipEnabled;
        }

        #endregion

        #region AttributeCombination

        public virtual ICollection<ProductAttributeCombination> ProductAttributeCombinations { get; protected set; }

        public virtual void AddProductAttributeCombination(Guid productAttributeCombinationId, int stockQuantity)
        {
            ProductAttributeCombinations.Add(new ProductAttributeCombination(productAttributeCombinationId, Id,
                Code, stockQuantity));
        }

        public virtual void RemoveProductAttributeCombination(Guid productAttributeCombinationId)
        {
            if (ProductAttributeCombinations.Any(x => x.Id == productAttributeCombinationId))
                ProductAttributeCombinations.RemoveAll(x => x.Id == productAttributeCombinationId);
        }

        #endregion

        #region Ctor

        protected Shippable()
        {
            ProductTags = new HashSet<ProductProductTag>();
            RequiredProducts = new HashSet<RequiredProduct>();
            RelatedProducts = new HashSet<RelatedProduct>();
            CrossSellProducts = new HashSet<CrossSellProduct>();
            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductProductAttributes = new HashSet<ProductProductAttribute>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductAttributeCombinations = new HashSet<ProductAttributeCombination>();
            ProductWarehouseInventories = new HashSet<ProductWarehouseInventory>();
        }

        public Shippable(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription,
            decimal price)
        {
            Id = id;
            SetCode(code);
            SetName(name);
            SetShortDescription(shortDescription);
            ChangePrice(price, false);
        }

        #endregion
    }
}