using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class DistrictUpdateDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Type { get; set; }

        public string Location { get; set; }
    }
}