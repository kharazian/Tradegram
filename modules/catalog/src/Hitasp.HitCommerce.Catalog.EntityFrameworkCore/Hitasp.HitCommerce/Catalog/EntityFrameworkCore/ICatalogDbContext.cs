using Hitasp.HitCommerce.Catalog.Brands.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [ConnectionStringName("Catalog")]
    public interface ICatalogDbContext : IEfCoreDbContext
    {
        DbSet<Brand> Brands { get; set; }
    }
}