using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Widgets;

namespace Hitasp.HitCommerce.MongoDB
{
    [ConnectionStringName("HitCommerce")]
    public interface IHitCommerceMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Address> Addresses { get; }
        
        IMongoCollection<Customer> Users { get; }
        
        IMongoCollection<Country> Countries { get; }
        
        IMongoCollection<StateOrProvince> StateOrProvinces { get; }
        
        IMongoCollection<District> Districts { get; }
        
        IMongoCollection<UserGroup> UserGroups { get; }
        
        IMongoCollection<Vendor> Vendors { get; }
        
        IMongoCollection<Widget> Widgets { get; }
        
        IMongoCollection<WidgetInstance> WidgetInstances { get; }
    }
}
