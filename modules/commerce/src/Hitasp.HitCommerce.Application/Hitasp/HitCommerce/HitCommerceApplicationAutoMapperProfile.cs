using AutoMapper;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Addresses.Dtos;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.Directions.Dtos;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.UserGroups.Dtos;
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
            
            CreateMap<AddressCreateDto, Address>()
                .ConstructUsing(x => 
                    new Address(
                        x.Phone,
                        x.AddressLine1,
                        x.AddressLine2,
                        x.City,
                        x.ZipCode,
                        x.CountryId,
                        x.StateOrProvinceId,
                        x.DistrictId)
                );
            
            CreateMap<AddressUpdateDto, Address>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetNewLine(src.Phone, src.AddressLine1, src.AddressLine2, src.City, src.ZipCode);
                    dest.SetNewDirection(src.CountryId, src.StateOrProvinceId, src.DistrictId);
                });

            CreateMap<UserGroup, UserGroupDto>();

            CreateMap<UserGroupCreateDto, UserGroup>()
                .ConstructUsing(x =>
                    new UserGroup(x.Name)
                );

            CreateMap<UserGroupUpdateDto, UserGroup>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetDescription(src.Description);
                    dest.UpdateStatus(src.IsActive);
                });

            CreateMap<Country, CountryDto>();

            CreateMap<CountryCreateDto, Country>()
                .ConstructUsing(x =>
                    new Country(x.Name, x.Code3)
                );

            CreateMap<CountryUpdateDto, Country>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name, src.Code3);
                });
            
            CreateMap<StateOrProvince, StateOrProvinceDto>();

            CreateMap<StateOrProvinceCreateDto, StateOrProvince>()
                .ConstructUsing(x =>
                    new StateOrProvince(x.CountryId, x.Name)
                );

            CreateMap<StateOrProvinceUpdateDto, StateOrProvince>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });
            
            CreateMap<District, DistrictDto>();

            CreateMap<DistrictCreateDto, District>()
                .ConstructUsing(x =>
                    new District(x.StateOrProvinceId, x.Name)
                );

            CreateMap<DistrictUpdateDto, District>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });
            
            CreateMap<Vendor, VendorDto>();

            CreateMap<VendorCreateDto, Vendor>()
                .ConstructUsing(x =>
                    new Vendor(x.Name, x.Slug)
                );

            CreateMap<VendorUpdateDto, Vendor>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetSlug(src.Slug);
                });

            CreateMap<Widget, WidgetDto>();

            CreateMap<WidgetCreateDto, Widget>()
                .ConstructUsing(x =>
                    new Widget(x.Name)
                );

            CreateMap<WidgetUpdateDto, Widget>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });
            
            CreateMap<WidgetInstance, WidgetInstanceDto>();

            CreateMap<WidgetInstanceCreateDto, WidgetInstance>()
                .ConstructUsing(x =>
                    new WidgetInstance(x.WidgetId, x.WidgetZoneId, x.Name)
                );

            CreateMap<WidgetInstanceUpdateDto, WidgetInstance>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetPublishingDate(src.PublishStart, src.PublishEnd);
                });

            CreateMap<WidgetZone, WidgetZoneDto>();

            CreateMap<WidgetZoneCreateDto, WidgetZone>()
                .ConstructUsing(x =>
                    new WidgetZone(x.Name)
                );

            CreateMap<WidgetZoneUpdateDto, WidgetZone>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });

        }
    }
}