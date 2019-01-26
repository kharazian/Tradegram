using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class VirtualProduct : Product
    {
        public virtual Guid? DownloadId { get; protected set; }

        public virtual bool UnlimitedDownloads { get; protected set; }

        public virtual int MaxNumberOfDownloads { get; protected set; }

        public virtual int? DownloadExpirationDays { get; protected set; }

        public virtual bool HasSampleDownload { get; protected set; }

        public virtual Guid? SampleDownloadId { get; protected set; }

        public virtual bool HasUserAgreement { get; protected set; }

        public virtual string UserAgreementText { get; protected set; }

        public virtual DownloadActivationType DownloadActivationType { get; set; }

        protected VirtualProduct()
        {
        }

        internal VirtualProduct(Guid id)
        {
            Id = id;

            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductTags = new HashSet<ProductTag>();
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            AttributeCombinations = new HashSet<ProductAttributeCombination>();
        }

        public void SetAsDownloadable(Guid downloadId, bool unlimitedDownloads, int maxNumberOfDownloads,
            int? downloadExpirationDays, bool hasSampleDownload, Guid? sampleDownloadId,
            DownloadActivationType downloadActivationType)
        {
            if (downloadId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(downloadId)} must be a valid identity");
            }

            if (!unlimitedDownloads && maxNumberOfDownloads <= 0)
            {
                throw new ArgumentException($"{nameof(maxNumberOfDownloads)} must be larger than zero");
            }

            if (hasSampleDownload && !sampleDownloadId.HasValue)
            {
                throw new ArgumentException($"{nameof(sampleDownloadId)} must be a valid identity");
            }

            if (downloadExpirationDays.HasValue && downloadExpirationDays.Value <= 0)
            {
                throw new ArgumentException($"{nameof(downloadExpirationDays)} must be larger than zero day");
            }

            if (DownloadId == downloadId && UnlimitedDownloads == unlimitedDownloads &&
                MaxNumberOfDownloads == maxNumberOfDownloads && DownloadExpirationDays == downloadExpirationDays &&
                HasSampleDownload == hasSampleDownload && SampleDownloadId == sampleDownloadId)
            {
                return;
            }

            DownloadId = downloadId;
            UnlimitedDownloads = unlimitedDownloads;
            MaxNumberOfDownloads = maxNumberOfDownloads;
            DownloadExpirationDays = downloadExpirationDays;
            HasSampleDownload = hasSampleDownload;
            SampleDownloadId = sampleDownloadId;
            DownloadActivationType = downloadActivationType;
        }

        public void SetUserAgreementText(bool hasUserAgreement, string userAgreementText = "")
        {
            if (string.IsNullOrWhiteSpace(userAgreementText))
            {
                HasUserAgreement = false;

                return;
            }

            if (HasUserAgreement == hasUserAgreement && UserAgreementText == userAgreementText)
            {
                return;
            }

            UserAgreementText = userAgreementText;
            HasUserAgreement = hasUserAgreement;
        }
    }
}