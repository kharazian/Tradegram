using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitLocation
{
    public class UserLocation : Entity
    {
        public virtual Guid UserId { get; protected set; }

        public virtual int LocationId { get; internal set; }

        public virtual DateTime UpdateDate { get; internal set; }

        protected UserLocation()
        {
        }

        public UserLocation(Guid userId, int locationId)
        {
            UserId = userId;
            LocationId = locationId;
            UpdateDate = DateTime.Now;
        }
        
        public override object[] GetKeys()
        {
            return new object[] {UserId, LocationId};
        }
    }
}