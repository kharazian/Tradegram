using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Contents
{
    public class EfCoreContentBaseRepository<TContent> : EfCoreRepository<IHitCommonDbContext, TContent, Guid>,
        IContentBaseRepository<TContent> where TContent : ContentBase
    {
        public EfCoreContentBaseRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<TContent> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }
        
        //TODO: more ...
    }
}