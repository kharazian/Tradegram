using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductFactory : IDomainService
    {
        [NotNull]
        Task<Product> CreatePhysicalProductAsync(Guid productTemplateId, [NotNull] string code,
            [NotNull] string name, [NotNull] string title, [NotNull] string shortDescription, decimal price,
            int stockQuantity);
        
        [NotNull]
        Task<Product> CreateVirtualProductAsync(Guid productTemplateId, [NotNull] string code,
            [NotNull] string name, [NotNull] string title, [NotNull] string shortDescription, decimal price);
    }
}