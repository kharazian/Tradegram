using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates
{
    public class Manufacturer : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual Guid ManufacturerTemplateId { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        public virtual string MetaTitle { get; protected set; }

        public virtual Guid? PictureId { get; protected set; }

        public virtual int PageSize { get; protected set; }

        public virtual bool AllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        public virtual string PriceRanges { get; set; }

        public virtual bool ShowOnHomePage { get; set; }

        public virtual bool IncludeInTopMenu { get; set; }

        public virtual bool Published { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual ICollection<ManufacturerDiscount> ManufacturerDiscounts { get; protected set; }


        protected Manufacturer()
        {
            ManufacturerDiscounts = new HashSet<ManufacturerDiscount>();
        }

        public Manufacturer(Guid id, Guid categoryTemplateId)
        {
            Id = id;

            ManufacturerTemplateId = categoryTemplateId;

            ManufacturerDiscounts = new HashSet<ManufacturerDiscount>();
        }


        public void SetManufacturerTemplate(Guid categoryTemplateId)
        {
            if (categoryTemplateId == Guid.Empty)
            {
                throw new InvalidIdentityException(nameof(categoryTemplateId));
            }

            ManufacturerTemplateId = categoryTemplateId;
        }

        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= ManufacturerConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {ManufacturerConsts.MaxNameLength}");
            }

            Name = name;
        }

        public void SetDescription(string description)
        {
            if (description.Length >= ManufacturerConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"{nameof(description)} can not be longer than {ManufacturerConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        public void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (metaTitle.Length >= ManufacturerConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException(
                    $"{nameof(metaTitle)} can not be longer than {ManufacturerConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= ManufacturerConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"{nameof(metaKeywords)} can not be longer than {ManufacturerConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= ManufacturerConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"{nameof(metaDescription)} can not be longer than {ManufacturerConsts.MaxMetaDescriptionLength}");
            }

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

        public void SetPageSize(int? pageSize = null)
        {
            if (!pageSize.HasValue)
            {
                PageSize = ManufacturerConsts.DefaultPageSize;

                return;
            }

            if (pageSize >= 0)
            {
                PageSize = ManufacturerConsts.DefaultPageSize;

                return;
            }

            PageSize = pageSize.Value;
        }

        public void AllowToSelectPageSize(bool allowCustomersToSelectPageSize = true,
            string pageSizeOptions = ManufacturerConsts.DefaultPageSizeOptions)
        {
            if (allowCustomersToSelectPageSize)
            {
                AllowCustomersToSelectPageSize = true;

                if (pageSizeOptions.IsNullOrWhiteSpace() || 
                    !pageSizeOptions.Split(',').Select(p => p.Trim()).GroupBy(p => p).Any(p => p.Count() > 1))
                {
                    PageSizeOptions = ManufacturerConsts.DefaultPageSizeOptions;

                    return;
                }

                PageSizeOptions = pageSizeOptions;

                return;
            }

            AllowCustomersToSelectPageSize = false;
        }

        public void SetPictureId(Guid? pictureId)
        {
            if (pictureId == Guid.Empty || pictureId == null)
            {
                PictureId = null;

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