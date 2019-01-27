using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Categories.Aggregates
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid CategoryTemplateId { get; protected set; }

        public virtual Guid CategoryInfoId { get; protected set; }

        public virtual CategoryInfo CategoryInfo { get; protected set; }

        public virtual Guid CategoryMetaId { get; protected set; }

        public virtual CategoryMeta CategoryMeta { get; protected set; }

        public virtual Guid CategoryPublishingInfoId { get; protected set; }

        public virtual CategoryPublishingInfo CategoryPublishingInfo { get; protected set; }

        public virtual Guid? PictureId { get; protected set; }

        public virtual Guid? ParentCategoryId { get; protected set; }

        public virtual ICollection<CategoryDiscount> CategoryDiscounts { get; protected set; }


        protected Category()
        {
            CategoryDiscounts = new HashSet<CategoryDiscount>();
        }

        internal Category(Guid id, Guid categoryTemplateId)
        {
            Id = id;

            CategoryTemplateId = categoryTemplateId;

            CategoryDiscounts = new HashSet<CategoryDiscount>();
        }

        internal void SetCategoryInfo(CategoryInfo categoryInfo)
        {
            CategoryInfoId = categoryInfo.Id;
            CategoryInfo = categoryInfo;
        }
        
        internal void SetCategoryMeta(CategoryMeta categoryMeta)
        {
            CategoryMetaId = categoryMeta.Id;
            CategoryMeta = categoryMeta;
        }
        
        internal void SetCategoryPublishingInfo(CategoryPublishingInfo categoryPublishingInfo)
        {
            CategoryPublishingInfoId = categoryPublishingInfo.Id;
            CategoryPublishingInfo = categoryPublishingInfo;
        }

        public void SetCategoryTemplate(Guid categoryTemplateId)
        {
            if (CategoryTemplateId == categoryTemplateId)
            {
                return;
            }

            if (categoryTemplateId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(categoryTemplateId)} must be a valid identity");
            }

            CategoryTemplateId = categoryTemplateId;
        }

        public void SetParentCategory(Guid parentCategoryId)
        {
            if (ParentCategoryId == parentCategoryId)
            {
                return;
            }

            if (parentCategoryId == Guid.Empty)
            {
                ParentCategoryId = null;

                return;
            }

            ParentCategoryId = parentCategoryId;
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
            CategoryDiscounts.Add(new CategoryDiscount(Id, discountId));
        }

        public void RemoveDiscount(Guid discountId)
        {
            if (CategoryDiscounts.Any(x => x.DiscountId == discountId))
            {
                CategoryDiscounts.RemoveAll(x => x.DiscountId == discountId);
            }
        }
    }
}