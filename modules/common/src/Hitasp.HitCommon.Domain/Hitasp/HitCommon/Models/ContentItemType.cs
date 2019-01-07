using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Models
{
    public class ContentItemType : AggregateRoot<string>
    {
        [NotNull]
        public virtual string Name => Id;

        public virtual bool IsMenuable { get; set; }

        [CanBeNull]
        public virtual string AreaName { get; protected set; }

        [CanBeNull]
        public virtual string RoutingController { get; protected set; }

        [CanBeNull]
        public virtual string RoutingAction { get; protected set; }

        protected ContentItemType()
        {
        }

        public ContentItemType([NotNull] string id)
        {
            Check.NotNullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public virtual void SetRouter(
            [NotNull] string areaName,
            [NotNull] string routingController,
            [NotNull] string routingAction)
        {
            Check.NotNullOrWhiteSpace(areaName, nameof(areaName));
            Check.NotNullOrWhiteSpace(routingController, nameof(routingController));
            Check.NotNullOrWhiteSpace(routingAction, nameof(routingAction));

            AreaName = areaName;
            RoutingController = routingController;
            RoutingAction = routingAction;
        }
    }
}