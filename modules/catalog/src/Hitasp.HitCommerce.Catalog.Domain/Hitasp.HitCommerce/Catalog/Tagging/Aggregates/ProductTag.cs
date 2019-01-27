using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Tagging.Aggregates
{
    public class ProductTag : AggregateRoot<Guid>
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public int UsageCount { get; protected internal set; }

        protected ProductTag()
        {
        }

        public ProductTag(Guid id, [NotNull] string name, int usageCount = 0, string description = null)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            IncreaseUsageCount(usageCount);
        }

        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            if (name.Length >= TaggingConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {TaggingConsts.MaxNameLength}");
            }

            Name = name;
        }

        public void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            if (description.Length >= TaggingConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {TaggingConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        public void IncreaseUsageCount(int number = 1)
        {
            UsageCount += number;
        }

        public void DecreaseUsageCount(int number = 1)
        {
            if (UsageCount <= 0)
            {
                return;
            }

            UsageCount -= number;
        }
    }
}