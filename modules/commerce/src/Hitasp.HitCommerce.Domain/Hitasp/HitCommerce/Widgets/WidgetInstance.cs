using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Widgets
{
    public class WidgetInstance : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid WidgetId { get; protected set; }

        public virtual int WidgetZoneId { get; protected set; }
        
        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual DateTimeOffset? PublishStart { get; protected set; }

        public virtual DateTimeOffset? PublishEnd { get; protected set; }

        public virtual int DisplayOrder { get; set; }

        public virtual string Data { get; set; }

        public virtual string HtmlData { get; set; }

        public bool IsPublished => PublishStart.HasValue && PublishStart.Value < DateTimeOffset.Now &&
                                   (!PublishEnd.HasValue || PublishEnd.Value > DateTimeOffset.Now);

        protected WidgetInstance()
        {
        }

        public WidgetInstance(Guid id, Guid widgetId, int widgetZoneId, [NotNull] string name)
        {
            Id = id;
            WidgetId = widgetId;
            WidgetZoneId = widgetZoneId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetPublishingDate(DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            if (startDate < DateTimeOffset.Now)
            {
                throw new UserFriendlyException("Can not set start date in the past!");
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                throw new UserFriendlyException("Can not set end date in the past of start date!");
            }

            PublishStart = startDate;
            PublishEnd = endDate;
        }
    }
}