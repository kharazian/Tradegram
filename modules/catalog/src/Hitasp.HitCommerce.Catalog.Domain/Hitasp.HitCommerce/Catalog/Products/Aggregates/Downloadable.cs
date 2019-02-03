using System;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Downloadable : Product
    {
        public virtual Guid DownloadId { get; protected set; }
        public virtual bool UnlimitedDownloads { get; protected set; }
        public virtual int MaxNumberOfDownloads { get; protected set; }
        public virtual int? DownloadExpirationDays { get; protected set; }
        public virtual int DownloadActivationTypeId { get; protected set; }
        public virtual bool HasSampleDownload { get; protected set; }
        public virtual Guid? SampleDownloadId { get; protected set; }
        public virtual bool HasUserAgreement { get; protected set; }
        public virtual string UserAgreementText { get; protected set; }

        public DownloadActivationType DownloadActivationType
        {
            get => (DownloadActivationType) DownloadActivationTypeId;
            set => DownloadActivationTypeId = (int) value;
        }

        protected Downloadable()
        {
        }

        public Downloadable(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription,
            decimal price, Guid downloadId) : base(id, code, name, shortDescription, price)
        {
            DownloadId = downloadId;
        }

        public virtual void SetAsDownloadable(Guid downloadId, bool unlimitedDownloads, int maxNumberOfDownloads,
            int? downloadExpirationDays, bool hasSampleDownload, Guid? sampleDownloadId,
            int downloadActivationTypeId)
        {
            if (downloadId == Guid.Empty)
            {
                IsDownload = false;

                return;
            }

            if (!unlimitedDownloads && maxNumberOfDownloads <= 0)
            {
                unlimitedDownloads = true;
            }

            if (hasSampleDownload && !sampleDownloadId.HasValue)
            {
                hasSampleDownload = false;
            }

            if (downloadExpirationDays.HasValue && downloadExpirationDays.Value <= 0)
            {
                downloadExpirationDays = 1;
            }

            DownloadId = downloadId;
            UnlimitedDownloads = unlimitedDownloads;
            MaxNumberOfDownloads = maxNumberOfDownloads;
            DownloadExpirationDays = downloadExpirationDays;
            HasSampleDownload = hasSampleDownload;
            SampleDownloadId = sampleDownloadId;
            DownloadActivationTypeId = downloadActivationTypeId;

            //TODO: Disable non-download properties(shipping, stock props, ...)
            SetShippingEnabled(false);
        }

        public virtual void SetUserAgreement(bool hasUserAgreement = false, string userAgreementText = "")
        {
            if (hasUserAgreement && string.IsNullOrWhiteSpace(userAgreementText))
            {
                HasUserAgreement = false;
                UserAgreementText = string.Empty;

                return;
            }

            HasUserAgreement = hasUserAgreement;
            UserAgreementText = userAgreementText;
        }
    }
}