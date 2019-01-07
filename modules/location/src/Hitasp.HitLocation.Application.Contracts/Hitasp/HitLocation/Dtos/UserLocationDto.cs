using System;

namespace Hitasp.HitLocation.Dtos
{
    public class UserLocationDto
    {
        public Guid UserId { get; set; }
        
        public int LocationId { get; set; }
        
        public DateTime UpdateDate { get; set; }
    }
}