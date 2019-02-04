using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
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
        public virtual GiftCard GiftCard { get; protected set; }

        public virtual void SetAsGiftCard(bool isGiftCard, decimal? overriddenGiftCardAmount = null)
        {
            if (isGiftCard)
            {
                if (overriddenGiftCardAmount <= decimal.Zero || overriddenGiftCardAmount == null)
                    overriddenGiftCardAmount = decimal.Zero;

                GiftCard = new GiftCard(Id, (int) GiftCardType.Physical, overriddenGiftCardAmount);
            }

            IsGiftCard = false;
            GiftCard = null;
        }

        #endregion

        #region Inventory

        public virtual ProductInventory Inventory { get; protected set; }

        internal virtual void SetProductInventory(ProductInventory productInventory)
        {
            if (Id != productInventory.ProductId) throw new InvalidIdentityException(nameof(productInventory));

            Inventory = productInventory;
        }

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
                    Inventory.ProductWarehouseInventories.First(x => x.WarehouseId == warehouseId);

                if (warehouseInventory != null)
                {
                    if (warehouseInventory.StockQuantity == 0)
                        throw new ArgumentException($"Empty stock, product item {Name} is sold out");

                    if (warehouseInventory.StockQuantity == quantity) return;

                    //sample distributed event
                    if (triggerEvent)
                        AddDistributedEvent(
                            new ProductStockQuantityChangedEto(Inventory.StockQuantity, quantity));

                    Inventory.ProductWarehouseInventories.First(x => x.WarehouseId == warehouseId)
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

        #endregion

        #region Shipping

        public virtual ProductShipping Shipping { get; protected set; }

        internal virtual void SetProductShipping(ProductShipping productShipping)
        {
            if (Id != productShipping.ProductId) throw new InvalidIdentityException(nameof(productShipping));

            Shipping = productShipping;
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
        }

        public Shippable(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription,
            decimal price)
        {
            Id = id;
            SetCode(code);
            SetName(name);
            SetShortDescription(shortDescription);
            SetProductPricing(new ProductPricing(id, price));
            SetProductInventory(new ProductInventory(id));
            SetProductShipping(new ProductShipping(id));
        }

        #endregion
    }
}