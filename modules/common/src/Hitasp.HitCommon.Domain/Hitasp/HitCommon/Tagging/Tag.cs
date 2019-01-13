using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.Tagging
{
    public class Tag : FullAuditedAggregateRoot<Guid>
    {
        public virtual string EntityTypeId { get; private set; }

        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual int UsageCount { get; protected internal set; }

        protected Tag()
        {
        }

        public Tag([NotNull] string entityTypeId, [NotNull] string name, int usageCount = 0, string description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(entityTypeId, nameof(entityTypeId));

            EntityTypeId = entityTypeId;
            Name = name;
            Description = description;
            UsageCount = usageCount;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Name = name;
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

        public virtual void SetDescription(string description)
        {
            Description = description;
        }
    }
}