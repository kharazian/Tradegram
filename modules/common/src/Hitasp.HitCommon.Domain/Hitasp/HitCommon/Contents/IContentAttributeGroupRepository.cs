using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Contents
{
    public interface IContentAttributeGroupRepository : IBasicRepository<ContentAttributeGroup, Guid>
    {
        Task<List<ContentAttributeGroup>> GetListAsync(string entityTypeId, CancellationToken cancellationToken = default);
        
        Task<ContentAttributeGroup> FindByNameAsync(string entityTypeId, string name, CancellationToken cancellationToken = default);
    }
}