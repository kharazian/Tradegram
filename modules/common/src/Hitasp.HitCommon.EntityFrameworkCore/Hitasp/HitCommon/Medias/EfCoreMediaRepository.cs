using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Medias
{
    public class EfCoreMediaRepository : EfCoreRepository<IHitCommonDbContext, Media, Guid>, IMediaRepository
    {
        
    public EfCoreMediaRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Media> FindByUniqueFileName(string uniqueFileName, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.UniqueFileName == uniqueFileName, cancellationToken);
    }
    }
}