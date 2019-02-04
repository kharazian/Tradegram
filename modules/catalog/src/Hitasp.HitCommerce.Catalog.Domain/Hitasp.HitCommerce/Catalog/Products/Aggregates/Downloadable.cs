using System;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Downloadable : Product
    {
        #region General

        public virtual Guid DownloadId { get; protected set; }
        public virtual bool UnlimitedDownloads { get; protected set; }
        public virtual int MaxNumberOfDownloads { get; protected set; }
        public virtual int? DownloadExpirationDays { get; protected set; }
        public virtual int DownloadActivationTypeId { get; protected set; }
        public virtual bool HasSampleDownload { get; protected set; }
        public virtual Guid? SampleDownloadId { get; protected set; }
        public DownloadActivationType DownloadActivationType
        {
            get => (DownloadActivationType) DownloadActivationTypeId;
            set => DownloadActivationTypeId = (int) value;
        }
        
        public virtual void SetAsDownload(Guid downloadId, bool unlimitedDownloads, int maxNumberOfDownloads,
            int? downloadExpirationDays, bool hasSampleDownload, Guid? sampleDownloadId,
            int downloadActivationTypeId)
        {
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
        }

        #endregion
        
        #region GiftCard

        public virtual bool IsGiftCard { get; protected set; }
        public virtual GiftCard GiftCard { get; protected set; }
        public virtual void SetAsGiftCard(bool isGiftCard, decimal? overriddenGiftCardAmount = null)
        {
            if (isGiftCard)
            {
                if (overriddenGiftCardAmount <= decimal.Zero || overriddenGiftCardAmount == null)
                {
                    overriddenGiftCardAmount = decimal.Zero;
                }
                
                GiftCard = new GiftCard(Id, (int) GiftCardType.Virtual, overriddenGiftCardAmount);
            }

            IsGiftCard = false;
            GiftCard = null;
        }

        #endregion

        #region User Agreement

        public virtual bool HasUserAgreement { get; protected set; }
        public virtual string UserAgreementText { get; protected set; }
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

        #endregion
        
        protected Downloadable()
        {
        }

        public Downloadable(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription)
        {
            Id = id;
            Code = code;
            SetName(name);
            SetShortDescription(shortDescription);
        }
    }
}