using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Tagging
{
    public interface ITagRepository : IBasicRepository<Tag, Guid>
    {
        Task<List<Tag>> GetListAsync(string entityTypeId);

        Task<Tag> GetByNameAsync(string entityTypeId, string name);

        Task<Tag> FindByNameAsync(string entityTypeId, string name);

        Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids);

        void DecreaseUsageCountOfTags(List<Guid> id);
    }
}
