using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates
{
    public class Manufacturer : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid ManufacturerTemplateId { get; protected set; }

        public virtual Guid ManufacturerInfoId { get; protected set; }

        public virtual ManufacturerInfo ManufacturerInfo { get; protected set; }

        public virtual Guid ManufacturerMetaId { get; protected set; }

        public virtual ManufacturerMeta ManufacturerMeta { get; protected set; }

        public virtual Guid ManufacturerPublishingInfoId { get; protected set; }

        public virtual ManufacturerPublishingInfo ManufacturerPublishingInfo { get; protected set; }

        public virtual Guid? PictureId { get; protected set; }

        public virtual ICollection<ManufacturerDiscount> ManufacturerDiscounts { get; protected set; }


        protected Manufacturer()
        {
            ManufacturerDiscounts = new HashSet<ManufacturerDiscount>();
        }

        internal Manufacturer(Guid id, Guid manufacturerTemplateId)
        {
            Id = id;
            
            ManufacturerTemplateId = manufacturerTemplateId;

            ManufacturerDiscounts = new HashSet<ManufacturerDiscount>();
        }
        
                
        internal void SetManufacturerInfo(ManufacturerInfo categoryInfo)
        {
            ManufacturerInfoId = categoryInfo.Id;
            ManufacturerInfo = categoryInfo;
        }
        
        internal void SetManufacturerMeta(ManufacturerMeta categoryMeta)
        {
            ManufacturerMetaId = categoryMeta.Id;
            ManufacturerMeta = categoryMeta;
        }
        
        internal void SetManufacturerPublishingInfo(ManufacturerPublishingInfo categoryPublishingInfo)
        {
            ManufacturerPublishingInfoId = categoryPublishingInfo.Id;
            ManufacturerPublishingInfo = categoryPublishingInfo;
        }

        public void SetManufacturerTemplate(Guid manufacturerTemplateId)
        {
            if (ManufacturerTemplateId == manufacturerTemplateId)
            {
                return;
            }

            if (manufacturerTemplateId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(manufacturerTemplateId)} must be a valid identity");
            }

            ManufacturerTemplateId = manufacturerTemplateId;
        }

        public void SetPictureId(Guid? pictureId)
        {
            if (pictureId == Guid.Empty || pictureId == null)
            {
                PictureId = null;
            }

            if (PictureId == pictureId)
            {
                return;
            }

            PictureId = pictureId;
        }
        
        public void AddDiscount(Guid discountId)
        {
            ManufacturerDiscounts.Add(new ManufacturerDiscount(Id, discountId));
        }

        public void RemoveDiscount(Guid discountId)
        {
            if (ManufacturerDiscounts.Any(x => x.DiscountId == discountId))
            {
                ManufacturerDiscounts.RemoveAll(x => x.DiscountId == discountId);
            }
        }
    }
}