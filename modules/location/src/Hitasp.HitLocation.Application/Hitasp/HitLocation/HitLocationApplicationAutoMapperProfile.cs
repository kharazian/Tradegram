using AutoMapper;
using Hitasp.HitLocation.Dtos;

namespace Hitasp.HitLocation
{
    public class HitLocationApplicationAutoMapperProfile : Profile
    {
        public HitLocationApplicationAutoMapperProfile()
        {
            CreateMap<Locations, LocationsDto>();
            
            CreateMap<UserLocation, UserLocationDto>();
        }
    }
}