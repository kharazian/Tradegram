using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class EfCoreProductCodeRepository : EfCoreRepository<ICatalogDbContext, ProductCode, Guid>,
        IProductCodeRepository
    {
        public EfCoreProductCodeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<bool> IsCodeExistsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await WithDetails().AnyAsync(x => x.Code == code, GetCancellationToken(cancellationToken));
        }
    }
}