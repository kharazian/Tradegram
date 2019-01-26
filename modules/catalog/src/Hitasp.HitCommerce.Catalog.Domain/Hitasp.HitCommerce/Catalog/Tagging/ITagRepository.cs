using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<List<Tag>> GetListAsync(Guid spaceId, CancellationToken cancellationToken = default);

        Task<Tag> GetByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default);

        Task<Tag> FindByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default);

        Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        void DecreaseUsageCountOfTags(List<Guid> ids);
    }
}
