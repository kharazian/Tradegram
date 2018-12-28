using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Medias
{
    public class EfCoreMediaRepository : EfCoreRepository<HitCommerceDbContext, Media, Guid>,
        IMediaRepository
    {
        public EfCoreMediaRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Media> GetByFileName(string fileName)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(fileName), x => x.FileName == fileName)
                .FirstOrDefaultAsync();
        }
    }
}