using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<bool> IsCodeExistsAsync([NotNull] string code, CancellationToken cancellationToken = default);
        
        Task<Product> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}