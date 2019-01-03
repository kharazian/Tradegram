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
            CreateMap<AddressCreateOrEditDto, Address>()
                .AfterMap((src, dest) =>
                {
                    dest.SetNewLine(src.Phone, src.AddressLine1, src.AddressLine2, src.City, src.ZipCode);
                    dest.SetNewDirection(src.CountryId, src.StateOrProvinceId, src.DistrictId);
                });

            CreateMap<UserGroup, UserGroupDto>();
            CreateMap<UserGroupCreateOrEditDto, UserGroup>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetDescription(src.Description);
                    dest.UpdateStatus(src.IsActive);
                });

            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateOrEditDto, Country>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name, src.Code3);
                });
            
            CreateMap<StateOrProvince, StateOrProvinceDto>();
            CreateMap<StateOrProvinceCreateOrEditDto, StateOrProvince>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });
            
            CreateMap<District, DistrictDto>();
            CreateMap<DistrictCreateOrEditDto, District>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });
            
            CreateMap<Vendor, VendorDto>();
            CreateMap<VendorCreateOrEditDto, Vendor>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetSlug(src.Slug);
                });

            CreateMap<Widget, WidgetDto>();
            CreateMap<WidgetCreateOrEditDto, Widget>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });
            
            CreateMap<WidgetInstance, WidgetInstanceDto>();
            CreateMap<WidgetInstanceCreateOrEditDto, WidgetInstance>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetPublishingDate(src.PublishStart, src.PublishEnd);
                });

            CreateMap<WidgetZone, WidgetZoneDto>();
            CreateMap<WidgetZoneCreateOrEditDto, WidgetZone>()
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                });

        }
    }
}