using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Categories.Entities
{
    public class CategoryInfo : Entity<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Title { get; protected set; }

        public virtual string Description { get; protected set; }

   
        protected CategoryInfo()
        {
        }

        internal CategoryInfo(Guid categoryId)
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
    }
}