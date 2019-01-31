using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class EfCoreManufacturerInfoRepository : EfCoreRepository<ICatalogDbContext, ManufacturerInfo, Guid>,
        IManufacturerInfoRepository
    {
        public EfCoreManufacturerInfoRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<ManufacturerInfo> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<ManufacturerInfo> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}