using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Entities
{
    public class ManufacturerInfo : Entity<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Title { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }


        protected ManufacturerInfo()
        {
        }

        internal ManufacturerInfo(Guid categoryId)
            : base(categoryId)
        {
        }


        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            if (name.Length >= ManufacturerConsts.MaxTitleLength)
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

        public void SetDisplayOrder(int displayOrder)
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
    }
}