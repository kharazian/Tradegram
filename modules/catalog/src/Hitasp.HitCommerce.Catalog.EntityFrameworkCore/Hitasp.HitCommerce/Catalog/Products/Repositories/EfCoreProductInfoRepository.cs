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
    public class EfCoreProductInfoRepository : EfCoreRepository<ICatalogDbContext, ProductInfo, Guid>,
        IProductInfoRepository
    {
        public EfCoreProductInfoRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<ProductInfo> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }
    }
}