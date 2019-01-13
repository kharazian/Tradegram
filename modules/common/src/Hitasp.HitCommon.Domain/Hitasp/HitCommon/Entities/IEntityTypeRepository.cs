using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Entities
{
    public interface IEntityTypeRepository : IBasicRepository<EntityType, string>
    {
        Task<List<EntityType>> GetListAsync(string areaName, CancellationToken cancellationToken = default);

        Task<EntityType> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}