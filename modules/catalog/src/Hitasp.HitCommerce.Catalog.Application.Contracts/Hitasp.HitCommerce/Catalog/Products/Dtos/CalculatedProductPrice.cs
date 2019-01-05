namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class CalculatedProductPrice
    {
        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public int PercentOfSaving { get; set; }
    }
}
