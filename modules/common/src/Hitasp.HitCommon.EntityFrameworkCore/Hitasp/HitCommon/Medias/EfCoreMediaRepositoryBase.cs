using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Medias
{
    public class EfCoreMediaRepositoryBase<TMedia, TDbContext> : EfCoreRepository<TDbContext, TMedia, Guid>, IMediaRepository<TMedia>
        where TDbContext : IEfCoreDbContext
        where TMedia : Media, IMedia

    {
    public EfCoreMediaRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<TMedia> FindByUniqueFileName(string uniqueFileName, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.UniqueFileName == uniqueFileName, cancellationToken);
    }
    }
}