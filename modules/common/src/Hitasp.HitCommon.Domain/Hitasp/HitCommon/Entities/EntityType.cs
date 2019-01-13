using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Entities
{
    public class EntityType : AggregateRoot<string>
    {
        public virtual string Name { get; private set; }

        public virtual bool IsMenuable { get; protected set; }

        public virtual string AreaName { get; protected set; }

        public virtual string RoutingController { get; protected set; }

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

        public virtual void SetAsMenuable(bool isMenuable = true)
        {
            IsMenuable = isMenuable;
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