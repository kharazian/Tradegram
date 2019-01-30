using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates
{
    public class Manufacturer : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid ManufacturerTemplateId { get; protected set; }

        public virtual ManufacturerInfo ManufacturerInfo { get; protected set; }

        public virtual ManufacturerMetaInfo ManufacturerMetaInfo { get; protected set; }

        public virtual ManufacturerPageInfo ManufacturerPageInfo { get; protected set; }

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

        internal void SetManufacturerInfo(ManufacturerInfo manufacturerInfo)
        {
            if (Id != manufacturerInfo.Id)
            {
                throw new InvalidIdentityException(nameof(manufacturerInfo));
            }

            ManufacturerInfo = manufacturerInfo;
        }

        internal void SetManufacturerMetaInfo(ManufacturerMetaInfo manufacturerMetaInfo)
        {
            if (Id != manufacturerMetaInfo.Id)
            {
                throw new InvalidIdentityException(nameof(manufacturerMetaInfo));
            }

            ManufacturerMetaInfo = manufacturerMetaInfo;
        }

        internal void SetManufacturerPageInfo(ManufacturerPageInfo manufacturerPageInfo)
        {
            if (Id != manufacturerPageInfo.Id)
            {
                throw new InvalidIdentityException(nameof(manufacturerPageInfo));
            }

            ManufacturerPageInfo = manufacturerPageInfo;
        }

        internal void SetManufacturerPublishingInfo(ManufacturerPublishingInfo manufacturerPublishingInfo)
        {
            if (Id != manufacturerPublishingInfo.Id)
            {
                throw new InvalidIdentityException(nameof(manufacturerPublishingInfo));
            }

            ManufacturerPublishingInfo = manufacturerPublishingInfo;
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
            if (ManufacturerDiscounts == null)
            {
                throw new ReferenceNotLoadedException(nameof(ManufacturerDiscounts));
            }

            if (ManufacturerDiscounts.Any(x => x.DiscountId == discountId))
            {
                ManufacturerDiscounts.RemoveAll(x => x.DiscountId == discountId);
            }
        }
    }
}