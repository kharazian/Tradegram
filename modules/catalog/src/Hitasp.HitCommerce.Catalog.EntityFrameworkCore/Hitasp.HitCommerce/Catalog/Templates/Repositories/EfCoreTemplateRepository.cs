using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Templates.Repositories
{
    public class EfCoreTemplateRepository : EfCoreRepository<ICatalogDbContext, Template, Guid>, 
        ITemplateRepository
    {
        public EfCoreTemplateRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Template>> GetListAsync(Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.SpaceId == spaceId).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Template> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }
    }
}