using System;

namespace Hitasp.HitCommerce.Catalog.Exceptions
{
    public class ReferenceNotLoadedException : NullReferenceException
    {
        public ReferenceNotLoadedException(string typeName)
            :base($"Reference with type {typeName} not loaded! Use `WithDetail()` in your repository method")
        {
            
        }
    }
}