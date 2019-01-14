using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class DistrictCreateDto
    {
        public Guid StateOrProvinceId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Type { get; set; }

        public string Location { get; set; }
    }
}