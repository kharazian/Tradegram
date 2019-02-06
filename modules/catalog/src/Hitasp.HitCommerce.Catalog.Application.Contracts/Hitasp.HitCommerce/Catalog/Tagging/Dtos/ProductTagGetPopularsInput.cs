namespace Hitasp.HitCommerce.Catalog.Tagging.Dtos
{
    public class ProductTagGetPopularsInput
    {
        public int ResultCount { get; set; } = 10;

        public int? MinimumUsageCount { get; set; }
    }
}