using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class EfCoreProductPriceInfoRepository : EfCoreRepository<ICatalogDbContext, ProductPriceInfo, Guid>,
        IProductPriceInfoRepository
    {
        public EfCoreProductPriceInfoRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }
    }
}