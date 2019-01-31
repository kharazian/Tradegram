using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Products.Exceptions
{
    public class ProductCodeAlreadyExistsException : BusinessException
    {
        public ProductCodeAlreadyExistsException(string productCode) 
            : base("PF:000001", $"A product with code {productCode} has already exists!")
        {
        }
    }
}