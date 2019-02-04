using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Tagging.Aggregates
{
    public class ProductTag : AggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual int UsageCount { get; protected internal set; }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= TaggingConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {TaggingConsts.MaxNameLength}");
            }

            Name = name;
        }

        public virtual void SetDescription(string description)
        {
            if (description.Length >= TaggingConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {TaggingConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        public virtual void IncreaseUsageCount(int number = 1)
        {
            UsageCount += number;
        }

        public virtual void DecreaseUsageCount(int number = 1)
        {
            if (UsageCount <= 0)
            {
                return;
            }

            UsageCount -= number;
        }
        
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
    }
}