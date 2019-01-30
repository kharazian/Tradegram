using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Categories.Exceptions
{
    public class CategoryNameAlreadyExistsException : BusinessException
    {
        public CategoryNameAlreadyExistsException(string categoryName) 
            : base("CF:000001", $"A category with name {categoryName} has already exists!")
        {
        }
    }
}