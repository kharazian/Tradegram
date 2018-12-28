using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
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
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class HitCommerceMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceBsonClassMap.Configure();

            context.Services.AddMongoDbContext<HitCommerceMongoDbContext>(options =>
            {
                options.AddRepository<Customer, MongoCustomerRepository>();
                options.AddRepository<CustomerAddress, MongoCustomerAddressRepository>();
                options.AddRepository<CustomerUserGroup, MongoCustomerUserGroupRepository>();
                options.AddRepository<Address, MongoAddressRepository>();
                options.AddRepository<UrlRecord, MongoUrlRecordRepository>();
                options.AddRepository<Country, MongoCountryRepository>();
                options.AddRepository<StateOrProvince, MongoStateOrProvinceRepository>();
                options.AddRepository<District, MongoDistrictRepository>();
                options.AddRepository<Media, MongoMediaRepository>();
                options.AddRepository<UserGroup, MongoUserGroupRepository>();
                options.AddRepository<Vendor, MongoVendorRepository>();
                options.AddRepository<Widget, MongoWidgetRepository>();
                options.AddRepository<WidgetInstance, MongoWidgetInstanceRepository>();
            });
        }
    }
}
