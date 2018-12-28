using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.Medias;
using Hitasp.HitCommerce.Seo;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Widgets;

namespace Hitasp.HitCommerce.MongoDB
{
    [ConnectionStringName("HitCommerce")]
    public class HitCommerceMongoDbContext : AbpMongoDbContext, IHitCommerceMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = HitCommerceConsts.DefaultDbTablePrefix;

        public IMongoCollection<Address> Addresses => Collection<Address>();
        
        public IMongoCollection<UrlRecord> UrlRecords => Collection<UrlRecord>();

        public IMongoCollection<Customer> Users => Collection<Customer>();
        
        public IMongoCollection<CustomerAddress> UserAddresses => Collection<CustomerAddress>();
        
        public IMongoCollection<CustomerUserGroup> CustomerUserGroups=> Collection<CustomerUserGroup>();
        
        public IMongoCollection<Country> Countries => Collection<Country>();
        
        public IMongoCollection<StateOrProvince> StateOrProvinces => Collection<StateOrProvince>();
        
        public IMongoCollection<District> Districts => Collection<District>();
        
        public IMongoCollection<UserGroup> UserGroups => Collection<UserGroup>();
        
        public IMongoCollection<Media> Medias => Collection<Media>();
        
        public IMongoCollection<Vendor> Vendors => Collection<Vendor>();
        
        public IMongoCollection<Widget> Widgets => Collection<Widget>();
        
        public IMongoCollection<WidgetInstance> WidgetInstances => Collection<WidgetInstance>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureHitCommerce(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}