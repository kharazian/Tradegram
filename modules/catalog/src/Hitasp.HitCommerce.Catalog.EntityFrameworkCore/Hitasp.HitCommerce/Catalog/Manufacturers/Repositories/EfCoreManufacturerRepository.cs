using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class EfCoreManufacturerRepository : EfCoreRepository<ICatalogDbContext, Manufacturer, Guid>,
        IManufacturerRepository
    {
        public EfCoreManufacturerRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Manufacturer> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.ManufacturerInfo.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<Manufacturer> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.ManufacturerInfo.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}