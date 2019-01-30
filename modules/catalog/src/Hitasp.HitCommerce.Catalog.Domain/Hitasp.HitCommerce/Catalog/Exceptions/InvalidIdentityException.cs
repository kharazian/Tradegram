using System;

namespace Hitasp.HitCommerce.Catalog.Exceptions
{
    public class InvalidIdentityException : ArgumentException
    {
        public InvalidIdentityException(string paramName) 
            : base($"{paramName} is not valid!")
        {
        }
    }
}