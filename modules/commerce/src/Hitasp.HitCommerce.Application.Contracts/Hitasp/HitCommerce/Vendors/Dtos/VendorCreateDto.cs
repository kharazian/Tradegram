using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Vendors.Dtos
{
    public class VendorCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}