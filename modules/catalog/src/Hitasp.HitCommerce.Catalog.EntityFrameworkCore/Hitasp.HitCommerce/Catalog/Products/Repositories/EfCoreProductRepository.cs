using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class EfCoreProductRepository : EfCoreRepository<ICatalogDbContext, Product, Guid>,
        IProductRepository
    {
        public EfCoreProductRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<bool> IsCodeExistsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await WithDetails().AnyAsync(x => x.ProductCode.Code == code, GetCancellationToken(cancellationToken));
        }

        public async Task<Product> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.ProductInfo.Name == name,
                GetCancellationToken(cancellationToken));
        }
    }
}