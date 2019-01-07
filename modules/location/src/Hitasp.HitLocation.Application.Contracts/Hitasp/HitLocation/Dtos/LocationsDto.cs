using MongoDB.Driver.GeoJsonObjectModel;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitLocation.Dtos
{
    public class LocationsDto : EntityDto<string>
    {
        public int LocationId { get; set; }

        public string Code { get; set; }

        public string ParentId { get; set; }

        public string Description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        public GeoJsonPolygon<GeoJson2DGeographicCoordinates> Polygon { get; set; }
    }
}