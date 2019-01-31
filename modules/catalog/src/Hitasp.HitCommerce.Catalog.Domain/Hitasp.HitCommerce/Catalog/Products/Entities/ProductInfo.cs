using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductInfo : Entity<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Title { get; protected set; }

        public virtual string ShortDescription { get; protected set; }

        public virtual string Description { get; protected set; }

        protected ProductInfo()
        {
        }

        internal ProductInfo(Guid productId) : base(productId)
        {
        }
        
         public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            if (name.Length >= ProductConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {ProductConsts.MaxNameLength}");
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

            if (title.Length >= ProductConsts.MaxTitleLength)
            {
                throw new ArgumentException($"Title can not be longer than {ProductConsts.MaxTitleLength}");
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            if (description.Length >= ProductConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {ProductConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        public void SetShortDescription([NotNull] string shortDescription)
        {
            Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));

            if (ShortDescription == shortDescription)
            {
                return;
            }

            if (shortDescription.Length >= ProductConsts.MaxShortDescriptionLength)
            {
                throw new ArgumentException(
                    $"Short description can not be longer than {ProductConsts.MaxShortDescriptionLength}");
            }

            ShortDescription = shortDescription;
        }
    }
}