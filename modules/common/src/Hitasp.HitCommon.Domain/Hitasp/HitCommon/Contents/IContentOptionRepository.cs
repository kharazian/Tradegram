using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Contents
{
    public interface IContentOptionRepository: IBasicRepository<ContentOption, Guid>
    {
        Task<List<ContentOption>> GetListAsync(string entityTypeId, CancellationToken cancellationToken = default);

        Task<ContentOption> FindByNameAsync(string entityTypeId, string name, CancellationToken cancellationToken = default);
    }
}