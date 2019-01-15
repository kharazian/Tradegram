using System;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.BinaryObjects
{
    public class MongoThumbnailImageRepository : MongoDbRepository<IHitCommonMongoDbContext, ThumbnailImage, Guid>, IThumbnailImageRepository
    {
        public MongoThumbnailImageRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<byte[]> GetBytes(Guid id)
        {
            return (await base.GetAsync(id)).BinaryData;
        }
    }
}
