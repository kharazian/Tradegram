using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Exceptions;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Categories.Aggregates
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid CategoryTemplateId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Title { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        public virtual int PageSize { get; protected set; }

        public virtual bool IsAllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        public virtual bool IsPublished { get; protected set; }

        public virtual bool ShowOnHomePage { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        public virtual Guid? PictureId { get; protected set; }

        public virtual Guid? ParentCategoryId { get; protected set; }

        public virtual ICollection<CategoryDiscount> CategoryDiscounts { get; protected set; }


        protected Category()
        {
            CategoryDiscounts = new HashSet<CategoryDiscount>();
        }

        public Category(Guid id, Guid categoryTemplateId)
        {
            Id = id;

            CategoryTemplateId = categoryTemplateId;

            CategoryDiscounts = new HashSet<CategoryDiscount>();
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

        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            if (name.Length >= CategoryConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {CategoryConsts.MaxNameLength}");
            }

            Name = name;
        }

        public void SetTitle([NotNull] string title)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));

            if (Title == title)
            {
                return;
            }

            if (title.Length >= CategoryConsts.MaxTitleLength)
            {
                throw new ArgumentException($"Title can not be longer than {CategoryConsts.MaxTitleLength}");
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            if (description.Length >= CategoryConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {CategoryConsts.MaxDescriptionLength}");
            }

            Description = description;
        }
        
        public void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (MetaTitle == metaTitle &&
                MetaKeywords == metaKeywords &&
                MetaDescription == metaDescription)
            {
                return;
            }

            if (metaTitle.Length >= CategoryConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException(
                    $"Meta Title can not be longer than {CategoryConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= CategoryConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"Meta Keywords can not be longer than {CategoryConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= CategoryConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"Meta Description can not be longer than {CategoryConsts.MaxMetaDescriptionLength}");
            }

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }
        
        public void SetPageSize(int? pageSize = null)
        {
            if (PageSize == pageSize)
            {
                return;
            }

            if (!pageSize.HasValue)
            {
                PageSize = CategoryConsts.DefaultPageSize;
            }

            if (pageSize >= 0)
            {
                throw new ArgumentException($"{nameof(pageSize)} can not be less than one!");
            }
        }

        public void AllowCustomersToSelectPageSize(bool isAllowCustomersToSelectPageSize = true,
            string pageSizeOption = CategoryConsts.DefaultPageSizeOptions)
        {
            if (isAllowCustomersToSelectPageSize)
            {
                IsAllowCustomersToSelectPageSize = true;
                PageSizeOptions = pageSizeOption;
            }

            IsAllowCustomersToSelectPageSize = false;
        }
        
        public void SetAsPublished(bool publish = true)
        {
            if (IsPublished == publish)
            {
                return;
            }

            IsPublished = publish;
        }

        public void SetAsHomePageItem(bool showOnHomePage = true)
        {
            if (ShowOnHomePage == showOnHomePage)
            {
                return;
            }

            ShowOnHomePage = showOnHomePage;
        }

        public void SetDisplayOrder(int displayOrder = 0)
        {
            if (displayOrder > 0)
            {
                throw new ArgumentException($"{nameof(displayOrder)} can not be less than zero!");
            }

            if (DisplayOrder == displayOrder)
            {
                return;
            }

            DisplayOrder = displayOrder;
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