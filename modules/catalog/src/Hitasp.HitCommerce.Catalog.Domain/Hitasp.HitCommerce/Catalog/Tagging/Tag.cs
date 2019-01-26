using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public class Tag : FullAuditedAggregateRoot<Guid>
    {
        public Guid? SpaceId { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public int UsageCount { get; protected internal set; }

        protected Tag()
        {
        }

        public Tag(Guid id, Guid? spaceId, [NotNull] string name, int usageCount = 0, string description = null)
        {
            Id = id;
            SpaceId = spaceId;
            SetName(name);
            SetDescription(description);
            IncreaseUsageCount(usageCount);
        }

        public Tag SetSpace(Guid? spaceId)
        {
            if (SpaceId == spaceId)
            {
                return this;
            }
            
            if (spaceId == null || spaceId == Guid.Empty)
            {
                SpaceId = null;
            }

            SpaceId = spaceId;

            return this;
        }

        public Tag SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return this;
            }

            if (name.Length >= TaggingConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {TaggingConsts.MaxNameLength}");
            }

            Name = name;

            return this;
        }

        public Tag SetDescription(string description)
        {
            if (Description == description)
            {
                return this;
            }

            if (description.Length >= TaggingConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {TaggingConsts.MaxDescriptionLength}");
            }

            Description = description;

            return this;
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