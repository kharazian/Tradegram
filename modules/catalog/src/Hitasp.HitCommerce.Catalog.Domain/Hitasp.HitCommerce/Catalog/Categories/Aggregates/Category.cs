using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Categories.Aggregates
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual Guid CategoryTemplateId { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        public virtual string MetaTitle { get; protected set; }

        public virtual Guid? ParentCategoryId { get; protected set; }

        public virtual Guid? PictureId { get; protected set; }

        public virtual int PageSize { get; protected set; }

        public virtual bool AllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        public virtual string PriceRanges { get; set; }

        public virtual bool ShowOnHomePage { get; set; }

        public virtual bool IncludeInTopMenu { get; set; }

        public virtual bool Published { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual ICollection<CategoryDiscount> CategoryDiscounts { get; protected set; }


        public virtual void SetCategoryTemplate(Guid categoryTemplateId)
        {
            if (categoryTemplateId == Guid.Empty)
            {
                throw new InvalidIdentityException(nameof(categoryTemplateId));
            }

            CategoryTemplateId = categoryTemplateId;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= CategoryConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {CategoryConsts.MaxNameLength}");
            }

            Name = name;
        }

        public virtual void SetDescription(string description)
        {
            if (description.Length >= CategoryConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"{nameof(description)} can not be longer than {CategoryConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        public virtual void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (metaTitle.Length >= CategoryConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException(
                    $"{nameof(metaTitle)} can not be longer than {CategoryConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= CategoryConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"{nameof(metaKeywords)} can not be longer than {CategoryConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= CategoryConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"{nameof(metaDescription)} can not be longer than {CategoryConsts.MaxMetaDescriptionLength}");
            }

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

        public virtual void SetPageSize(int? pageSize = null)
        {
            if (!pageSize.HasValue)
            {
                PageSize = CategoryConsts.DefaultPageSize;

                return;
            }

            if (pageSize >= 0)
            {
                PageSize = CategoryConsts.DefaultPageSize;

                return;
            }

            PageSize = pageSize.Value;
        }

        public virtual void AllowToSelectPageSize(bool allowCustomersToSelectPageSize = true,
            string pageSizeOptions = CategoryConsts.DefaultPageSizeOptions)
        {
            if (allowCustomersToSelectPageSize)
            {
                AllowCustomersToSelectPageSize = true;

                if (pageSizeOptions.IsNullOrWhiteSpace() || 
                    !pageSizeOptions.Split(',').Select(p => p.Trim()).GroupBy(p => p)
                        .Any(p => p.Count() > 1))
                {
                    PageSizeOptions = CategoryConsts.DefaultPageSizeOptions;

                    return;
                }

                PageSizeOptions = pageSizeOptions;

                return;
            }

            AllowCustomersToSelectPageSize = false;
        }

        public virtual void SetParentCategory(Guid parentCategoryId)
        {
            if (parentCategoryId == Guid.Empty)
            {
                ParentCategoryId = null;

                return;
            }

            ParentCategoryId = parentCategoryId;
        }

        public virtual void SetPictureId(Guid? pictureId)
        {
            if (pictureId == Guid.Empty || pictureId == null)
            {
                PictureId = null;

                return;
            }

            PictureId = pictureId;
        }

        public virtual void AddDiscount(Guid discountId)
        {
            CategoryDiscounts.Add(new CategoryDiscount(Id, discountId));
        }

        public virtual void RemoveDiscount(Guid discountId)
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
        
        protected Category()
        {
            CategoryDiscounts = new HashSet<CategoryDiscount>();
        }

        public Category(Guid id, Guid categoryTemplateId)
        {
            Id = id;

            CategoryTemplateId = categoryTemplateId;
        }
    }
}