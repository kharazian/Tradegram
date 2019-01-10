using System;

namespace Hitasp.HitCommon.Addresses
{
    [Flags]
    public enum AddressType : byte
    {
        Undef = 0,
        Billing = 1,
        Shipping = 2,
        Pickup = 3,
        BillingAndShipping = Billing | Shipping
    }
}
