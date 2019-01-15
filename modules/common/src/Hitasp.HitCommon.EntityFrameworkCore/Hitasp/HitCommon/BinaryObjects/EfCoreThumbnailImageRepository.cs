using System;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.BinaryObjects
{
    public class EfCoreThumbnailImageRepository : EfCoreRepository<IHitCommonDbContext, ThumbnailImage, Guid>,
        IThumbnailImageRepository
    {
        public EfCoreThumbnailImageRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<byte[]> GetBytes(Guid id)
        {
            return (await base.GetAsync(id)).BinaryData;
        }
    }
}