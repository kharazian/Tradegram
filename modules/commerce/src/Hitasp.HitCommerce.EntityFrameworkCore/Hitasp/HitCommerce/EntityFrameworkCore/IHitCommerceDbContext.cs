using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Widgets;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    [ConnectionStringName("HitCommerce")]
    public interface IHitCommerceDbContext : IEfCoreDbContext
    {
        DbSet<Address> Addresses { get; set; }
        
        DbSet<Customer> Users { get; set; }
        
        DbSet<Country> Countries { get; set; }
        
        DbSet<StateOrProvince> StateOrProvinces { get; set; }
        
        DbSet<District> Districts { get; set; }
        
        DbSet<UserGroup> UserGroups { get; set; }
        
        DbSet<Vendor> Vendors { get; set; }
        
        DbSet<Widget> Widgets { get; set; }
        
        DbSet<WidgetInstance> WidgetInstances { get; set; }
    }
}