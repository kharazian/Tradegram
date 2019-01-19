using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public class EfCoreContentBaseRepository<TContent, TContext> : EfCoreRepository<TContext, TContent, Guid>,
        IContentBaseRepository<TContent> 
        where TContent : Content
        where TContext : IEfCoreDbContext
    {
        public EfCoreContentBaseRepository(IDbContextProvider<TContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<TContent> FindByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Title == title,
                GetCancellationToken(cancellationToken));
        }
        
        //TODO: more ...
    }
}