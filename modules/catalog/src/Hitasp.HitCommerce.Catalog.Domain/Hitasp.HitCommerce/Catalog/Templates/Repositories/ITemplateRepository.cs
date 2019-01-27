using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Templates.Repositories
{
    public interface ITemplateRepository : IRepository<Template, Guid>
    {
        [CanBeNull]
        Task<Template> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}