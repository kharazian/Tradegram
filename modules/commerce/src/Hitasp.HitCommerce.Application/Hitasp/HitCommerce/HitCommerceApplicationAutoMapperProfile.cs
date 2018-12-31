using AutoMapper;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Addresses.Dtos;
using Hitasp.HitCommerce.Customers.Dtos;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.Directions.Dtos;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Vendors.Dtos;
using Hitasp.HitCommerce.Widgets;
using Hitasp.HitCommerce.Widgets.Dtos;

namespace Hitasp.HitCommerce
{
    public class HitCommerceApplicationAutoMapperProfile : Profile
    {
        public HitCommerceApplicationAutoMapperProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<Address, AddressCreateOrEditDto>();
            
            CreateMap<UserGroup, CustomerGroupDto>();
            CreateMap<UserGroup, CustomerGroupCreateOrEditDto>();
            
            CreateMap<Country, CountryDto>();
            CreateMap<StateOrProvince, StateOrProvinceDto>();
            CreateMap<District, DistrictDto>();
            
            CreateMap<Vendor, VendorDto>();
            
            CreateMap<Widget, WidgetDto>();
            CreateMap<WidgetInstance, WidgetInstanceDto>();
            CreateMap<WidgetZone, WidgetZoneDto>();
        }
    }
}