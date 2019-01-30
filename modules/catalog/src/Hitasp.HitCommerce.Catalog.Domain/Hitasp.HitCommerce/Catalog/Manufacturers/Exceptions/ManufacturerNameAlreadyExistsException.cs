using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Exceptions
{
    public class ManufacturerNameAlreadyExistsException : BusinessException
    {
        public ManufacturerNameAlreadyExistsException(string manufacturerName) 
            : base("MF:000001", $"A manufacturer with name {manufacturerName} has already exists!")
        {
        }
    }
}