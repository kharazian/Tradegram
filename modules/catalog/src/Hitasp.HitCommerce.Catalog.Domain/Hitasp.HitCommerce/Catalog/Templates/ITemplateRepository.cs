using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Templates
{
    public interface ITemplateRepository : IRepository<Template, Guid>
    {
        Task<List<Template>> GetListAsync(Guid spaceId, CancellationToken cancellationToken = default);
        
        [CanBeNull]
        Task<Template> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}