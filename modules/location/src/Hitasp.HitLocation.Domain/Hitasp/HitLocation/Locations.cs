using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitLocation
{
    public class Locations : Entity<string>
    {
        public virtual int LocationId { get; set; }

        public virtual string Code { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string ParentId { get; set; }

        public virtual string Description { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        public virtual GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; private set; }

        public virtual GeoJsonPolygon<GeoJson2DGeographicCoordinates> Polygon { get; private set; }

        public virtual void SetLocation(double lon, double lat) => SetPosition(lon, lat);

        public virtual void SetArea(IEnumerable<GeoJson2DGeographicCoordinates> coordinatesList) => SetPolygon(coordinatesList);

        private void SetPosition(double lon, double lat)
        {
            Latitude = lat;
            Longitude = lon;

            Location = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(lon, lat));
        }

        private void SetPolygon(IEnumerable<GeoJson2DGeographicCoordinates> coordinatesList)
        {
            Polygon = new GeoJsonPolygon<GeoJson2DGeographicCoordinates>(
                new GeoJsonPolygonCoordinates<GeoJson2DGeographicCoordinates>(
                    new GeoJsonLinearRingCoordinates<GeoJson2DGeographicCoordinates>(coordinatesList)));
        }
    }
}