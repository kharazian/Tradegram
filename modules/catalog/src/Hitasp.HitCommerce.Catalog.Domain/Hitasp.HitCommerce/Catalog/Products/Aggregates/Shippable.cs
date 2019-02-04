using System;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Etos;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Shippable : Product
    {
        #region GiftCard

        public bool IsGiftCard { get; protected set; }
        public GiftCard GiftCard { get; protected set; }
        public void SetAsGiftCard(bool isGiftCard, decimal? overriddenGiftCardAmount = null)
        {
            if (isGiftCard)
            {
                if (overriddenGiftCardAmount <= decimal.Zero || overriddenGiftCardAmount == null)
                {
                    overriddenGiftCardAmount = decimal.Zero;
                }
                
                GiftCard = new GiftCard(Id, (int) GiftCardType.Physical, overriddenGiftCardAmount);
            }

            IsGiftCard = false;
            GiftCard = null;
        }

        #endregion

        #region Inventory

        public ProductInventory ProductInventory { get; protected set; }

        private void SetProductInventory(ProductInventory productInventory)
        {
            if (Id != productInventory.ProductId)
            {
                throw new InvalidIdentityException(nameof(productInventory));
            }
            
            ProductInventory = productInventory;
        }

        public void RemoveStock(int quantityDesired, Guid? warehouseId = null)
        {
            if (ProductInventory.UseMultipleWarehouses && warehouseId == null)
                throw new ArgumentException(
                    $"{nameof(warehouseId)} must be a valid identity!");

            if (!ProductInventory.UseMultipleWarehouses && ProductInventory.StockQuantity == 0)
                throw new ArgumentException($"Empty stock, product item {Name} is sold out");

            if (quantityDesired <= 0)
                throw new ArgumentException("Item units desired should be greater than zero");

            var removed = Math.Min(quantityDesired, ProductInventory.StockQuantity);

            SetStockQuantityInternal(ProductInventory.StockQuantity - removed, warehouseId);
        }

        public void AddStock(int quantity = 0, Guid? warehouseId = null)
        {
            if (quantity < 0)
            {
                return;
            }

            SetStockQuantityInternal(ProductInventory.StockQuantity + quantity, warehouseId);
        }

        private void SetStockQuantityInternal(int quantity, Guid? warehouseId = null, bool triggerEvent = true)
        {
            if (warehouseId.HasValue && warehouseId != Guid.Empty)
            {
                var warehouseInventory =
                    ProductInventory.ProductWarehouseInventories.First(x => x.WarehouseId == warehouseId);

                if (warehouseInventory != null)
                {
                                
                    if (warehouseInventory.StockQuantity == 0)
                        throw new ArgumentException($"Empty stock, product item {Name} is sold out");
                    
                    if (warehouseInventory.StockQuantity == quantity)
                    {
                        return;
                    }

                    //sample distributed event
                    if (triggerEvent)
                    {
                        AddDistributedEvent(
                            new ProductStockQuantityChangedEto(ProductInventory.StockQuantity, quantity));
                    }

                    ProductInventory.ProductWarehouseInventories.First(x => x.WarehouseId == warehouseId)
                        .SetStockQuantity(quantity);

                    return;
                }
            }

            if (ProductInventory.StockQuantity == quantity)
            {
                return;
            }

            //sample distributed event
            if (triggerEvent)
            {
                AddDistributedEvent(new ProductStockQuantityChangedEto(ProductInventory.StockQuantity, quantity));
            }

            ProductInventory.SetStockQuantity(quantity);
        }

        #endregion

        protected Shippable()
        {
            
        }
        
        public Shippable(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription)
        {
            Id = id;
            Code = code;
            SetName(name);
            SetShortDescription(shortDescription);
            
            SetProductInventory(new ProductInventory(id));
        }
    }
}