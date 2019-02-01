using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates
{
    public class Manufacturer : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid ManufacturerTemplateId { get; protected set; }

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

        public virtual ICollection<ManufacturerDiscount> ManufacturerDiscounts { get; protected set; }


        protected Manufacturer()
        {
            ManufacturerDiscounts = new HashSet<ManufacturerDiscount>();
        }

        public Manufacturer(Guid id, Guid manufacturerTemplateId)
        {
            Id = id;

            ManufacturerTemplateId = manufacturerTemplateId;

            ManufacturerDiscounts = new HashSet<ManufacturerDiscount>();
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

        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            if (name.Length >= ManufacturerConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {ManufacturerConsts.MaxNameLength}");
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

            if (title.Length >= ManufacturerConsts.MaxTitleLength)
            {
                throw new ArgumentException($"Title can not be longer than {ManufacturerConsts.MaxTitleLength}");
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            if (description.Length >= ManufacturerConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {ManufacturerConsts.MaxDescriptionLength}");
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

            if (metaTitle.Length >= ManufacturerConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException(
                    $"Meta Title can not be longer than {ManufacturerConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= ManufacturerConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"Meta Keywords can not be longer than {ManufacturerConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= ManufacturerConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"Meta Description can not be longer than {ManufacturerConsts.MaxMetaDescriptionLength}");
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
                PageSize = ManufacturerConsts.DefaultPageSize;
            }

            if (pageSize >= 0)
            {
                throw new ArgumentException($"{nameof(pageSize)} can not be less than one!");
            }
        }

        public void AllowCustomersToSelectPageSize(bool isAllowCustomersToSelectPageSize = true,
            string pageSizeOption = ManufacturerConsts.DefaultPageSizeOptions)
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