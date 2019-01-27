using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitSocial.MongoDB
{
    [ConnectionStringName("HitSocial")]
    public interface IHitSocialMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
