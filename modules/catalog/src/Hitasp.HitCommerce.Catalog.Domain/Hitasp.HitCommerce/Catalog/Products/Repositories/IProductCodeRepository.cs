using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductCodeRepository : IRepository<ProductCode, Guid>
    {
        Task<bool> IsCodeExistsAsync([NotNull] string code, CancellationToken cancellationToken = default);
    }
}