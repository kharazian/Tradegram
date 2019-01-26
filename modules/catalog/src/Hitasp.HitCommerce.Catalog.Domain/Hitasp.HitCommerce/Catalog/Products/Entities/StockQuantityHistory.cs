using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class StockQuantityHistory : CreationAuditedEntity<Guid>
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual int QuantityAdjustment { get; protected set; }

        public virtual int StockQuantity { get; protected set; }

        public virtual string Message { get; protected set; }

        public virtual Guid? CombinationId { get; protected set; }

        public virtual Guid? WarehouseId { get; protected set; }

        
        protected StockQuantityHistory()
        {
        }

        public StockQuantityHistory(Guid id, Guid productId, int quantityAdjustment, int stockQuantity, string message = "",
            Guid? combinationId = null, Guid? warehouseId = null)
        {
            Id = id;
            
            ProductId = productId;
            QuantityAdjustment = quantityAdjustment;
            StockQuantity = stockQuantity;
            Message = message;
            CombinationId = combinationId;
            WarehouseId = warehouseId;
        }
    }
}