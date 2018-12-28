using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class DistrictCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Type { get; set; }

        public string Location { get; set; }
    }
}