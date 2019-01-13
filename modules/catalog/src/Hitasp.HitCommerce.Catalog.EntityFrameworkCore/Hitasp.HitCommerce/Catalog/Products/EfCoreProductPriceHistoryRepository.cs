using System;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductPriceHistoryRepository : EfCoreRepository<IHitCommonDbContext, ProductPriceHistory, Guid>, 
        IProductPriceHistoryRepository
    {
        public EfCoreProductPriceHistoryRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}