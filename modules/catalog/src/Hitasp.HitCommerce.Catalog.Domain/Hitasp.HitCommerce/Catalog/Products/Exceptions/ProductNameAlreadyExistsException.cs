using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Products.Exceptions
{
    public class ProductNameAlreadyExistsException : BusinessException
    {
        public ProductNameAlreadyExistsException(string productName) 
            : base("PF:000002", $"A product with name {productName} has already exists!")
        {
        }
    }
}