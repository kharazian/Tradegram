using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductTemplateRepository : EfCoreRepository<ICatalogDbContext, ProductTemplate, Guid>, IProductTemplateRepository
    {
        public EfCoreProductTemplateRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}