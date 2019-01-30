using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Categories.Aggregates
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid CategoryTemplateId { get; protected set; }

        public virtual CategoryInfo CategoryInfo { get; protected set; }

        public virtual CategoryMetaInfo CategoryMetaInfo { get; protected set; }

        public virtual CategoryPageInfo CategoryPageInfo { get; protected set; }

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
            if (Id == categoryInfo.Id)
            {
                CategoryInfo = categoryInfo;
            }
            
            throw new InvalidIdentityException(nameof(categoryInfo));
        }

        internal void SetCategoryMetaInfo(CategoryMetaInfo categoryMetaInfo)
        {
            if (Id == categoryMetaInfo.Id)
            {
                CategoryMetaInfo = categoryMetaInfo;
            }
            
            throw new InvalidIdentityException(nameof(categoryMetaInfo));
        }

        internal void SetCategoryPageInfo(CategoryPageInfo categoryPageInfo)
        {
            if(Id == categoryPageInfo.Id)
            {
                CategoryPageInfo = categoryPageInfo;
            }
            
            throw new InvalidIdentityException(nameof(categoryPageInfo));
        }

        internal void SetCategoryPublishingInfo(CategoryPublishingInfo categoryPublishingInfo)
        {
            if(Id == categoryPublishingInfo.Id)
            {
                CategoryPublishingInfo = categoryPublishingInfo;
            }
            
            throw new InvalidIdentityException(nameof(categoryPublishingInfo));
        }

        public void SetCategoryTemplate(Guid categoryTemplateId)
        {
            if (CategoryTemplateId == categoryTemplateId)
            {
                return;
            }

            if (categoryTemplateId == Guid.Empty)
            {
                throw new InvalidIdentityException(nameof(categoryTemplateId));
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
            if (CategoryDiscounts == null)
            {
                throw new ReferenceNotLoadedException(nameof(CategoryDiscounts));
            }

            if (CategoryDiscounts.Any(x => x.DiscountId == discountId))
            {
                CategoryDiscounts.RemoveAll(x => x.DiscountId == discountId);
            }
        }
    }
}