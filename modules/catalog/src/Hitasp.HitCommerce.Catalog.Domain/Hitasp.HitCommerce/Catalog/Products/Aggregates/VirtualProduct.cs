using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using JetBrains.Annotations;
using Volo.Abp;

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

        public virtual DownloadActivationType DownloadActivationType { get; set; }

        protected VirtualProduct()
        {
        }

        internal VirtualProduct(Guid id, [NotNull] string code, [NotNull] string name, decimal price)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
            {
                throw new ArgumentException($"Code can not be longer than {ProductConsts.MaxCodeLength}");
            }
            
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(price)} can not be less than 0.0!");
            }


            Id = id;
            Code = code;
            Price = price;

            SetName(name);

            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductTags = new HashSet<ProductProductTag>();
            ProductAttributes = new HashSet<ProductProductAttribute>();
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
    }
}