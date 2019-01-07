using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    [ConnectionStringName("HitLocation")]
    public class HitLocationMongoDbContext : AbpMongoDbContext, IHitLocationMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = HitLocationConsts.DefaultDbTablePrefix;

        public IMongoCollection<Locations> Locations => Collection<Locations>();
        
        public IMongoCollection<UserLocation> UserLocations => Collection<UserLocation>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureHitLocation(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}