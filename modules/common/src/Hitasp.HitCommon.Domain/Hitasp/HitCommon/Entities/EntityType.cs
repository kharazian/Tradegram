using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Entities
{
    public class EntityType : AggregateRoot<string>
    {
        [NotNull] public virtual string Name { get; protected set; }

        public virtual bool IsMenuable { get; set; }

        [CanBeNull]
        public virtual string AreaName { get; protected set; }

        [CanBeNull]
        public virtual string RoutingController { get; protected set; }

        [CanBeNull]
        public virtual string RoutingAction { get; protected set; }

        protected EntityType()
        {
        }

        public EntityType([NotNull] string id, string name)
        {
            Check.NotNullOrWhiteSpace(id, nameof(id));
            
            Id = id;
            Name = string.IsNullOrWhiteSpace(name) ? id : name;
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