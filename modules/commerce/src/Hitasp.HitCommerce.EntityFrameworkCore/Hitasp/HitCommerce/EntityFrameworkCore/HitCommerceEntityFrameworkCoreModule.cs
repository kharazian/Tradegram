using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Widgets;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class HitCommerceEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HitCommerceDbContext>(options =>
            {
                options.AddRepository<Customer, EfCoreCustomerRepository>();
                options.AddRepository<Address, EfCoreAddressRepository>();
                options.AddRepository<Country, EfCoreCountryRepository>();
                options.AddRepository<StateOrProvince, EfCoreStateOrProvinceRepository>();
                options.AddRepository<District, EfCoreDistrictRepository>();
                options.AddRepository<UserGroup, EfCoreUserGroupRepository>();
                options.AddRepository<Vendor, EfCoreVendorRepository>();
                options.AddRepository<Widget, EfCoreWidgetRepository>();
                options.AddRepository<WidgetZone, EfCoreWidgetZoneRepository>();
                options.AddRepository<WidgetInstance, EfCoreWidgetInstanceRepository>();
            });
        }
    }
}